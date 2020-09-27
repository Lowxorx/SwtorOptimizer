using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Calculator.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SwtorOptimizer.Calculator.Workers
{
    public class SetCalculatorWorker : BackgroundService
    {
        private readonly ISwtorOptimizerDatabaseService context;
        private readonly ILogger<SetCalculatorWorker> logger;
        private readonly IOptions<CalculatorSettings> settings;

        public SetCalculatorWorker(ILogger<SetCalculatorWorker> logger, IOptions<CalculatorSettings> settings, ISwtorOptimizerDatabaseService context)
        {
            this.logger = logger;
            this.context = context;
            this.settings = settings;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Starting SetCalculatorWorker service...");
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Run(this.CheckAndStartTasks, cancellationToken);
                await Task.Delay(TimeSpan.FromSeconds(this.settings.Value.TaskInterval), cancellationToken);
            }
        }

        private async void CheckAndStartTasks()
        {
            var tasks = new List<FindCombinationTask>();

            try
            {
                tasks = await this.context.FindCombinationTaskRepository.All().Where(e => e.EndDate == default && e.Status == FindCombinationTaskStatus.Idle).ToListAsync();
            }
            catch (Exception e)
            {
                this.logger.LogError(e, $"Task error : {e.Message}");
            }

            if (tasks.Count == 0)
            {
                this.logger.LogInformation($"No task found. Standby for {this.settings.Value.TaskInterval} seconds... ");
                return;
            }

            this.logger.LogInformation($"We have a job to do. Let's launch {tasks.Count} job");
            var enhancements = this.context.EnhancementRepository.All().ToList();

            foreach (var task in tasks)
            {
                await Task.Run(() => this.StartTask(task, enhancements)).ContinueWith((result) =>
                {
                    if (result.IsFaulted)
                    {
                        task.Status = FindCombinationTaskStatus.Faulted;
                        task.EndDate = DateTime.Now;
                        task.FoundSets = 0;
                        this.context.FindCombinationTaskRepository.Update(task.Id, task, true);

                        if (result.Exception != null)
                        {
                            this.logger.LogError(result.Exception, $"Task error : {result.Exception.Message}");
                        }
                    }
                    else
                    {
                        this.logger.LogInformation("Task completed successfully.");
                    }
                });
            }
        }

        private IEnumerable<string> GetCombinations(IReadOnlyList<Enhancement> enhancements, int threshold, string values)
        {
            foreach (var enhancement in enhancements)
            {
                var left = threshold - enhancement.Tertiary;
                if (left < 0)
                {
                    continue;
                }
                var vals = enhancement.Id + " " + values;
                if (left == 0)
                {
                    yield return vals.Trim();
                }
                else
                {
                    foreach (var s in this.GetCombinations(enhancements, left, vals))
                    {
                        yield return s.Trim();
                    }
                }
            }
        }

        private async void StartTask(FindCombinationTask task, List<Enhancement> enhancements)
        {
            task.Status = FindCombinationTaskStatus.Started;
            task.StartDate = DateTime.Now;
            task.FoundSets = 0;
            await this.context.FindCombinationTaskRepository.UpdateAsync(task.Id, task, true);

            foreach (var combination in this.GetCombinations(enhancements, task.Threshold, string.Empty))
            {
                var newSetFound = combination.Split(' ').Select(result => enhancements.First(e => e.Id.Equals(Convert.ToInt32(result)))).ToList();

                var setName = string.Join(';', newSetFound.OrderBy(e => e.Name).Select(e => e.Name).ToArray());

                // if (this.context.EnhancementSetRepository.All().FirstOrDefaultAsync(es =>
                // es.SetName.Equals(setName)) != null) continue;

                var newSet = await this.context.EnhancementSetRepository.AddAsync(new EnhancementSet { SetName = setName, Threshold = task.Threshold, IsInvalid = false }, true);
                task.FoundSets++;

                var enhancementSetEnhancements = new List<EnhancementSetEnhancement>();
                enhancementSetEnhancements.AddRange(newSetFound.Select(e => new EnhancementSetEnhancement { EnhancementSetId = newSet.Id, EnhancementId = e.Id }));
                await this.context.FindCombinationTaskRepository.UpdateAsync(task.Id, task, true);

                await this.context.EnhancementSetEnhancementRepository.AddAllAsync(enhancementSetEnhancements);
            }

            if (task.FoundSets == 0)
            {
                await this.context.EnhancementSetRepository.AddAsync(new EnhancementSet { SetName = "Invalid", Threshold = task.Threshold, IsInvalid = true }, true);
            }

            task.Status = FindCombinationTaskStatus.Ended;
            task.EndDate = DateTime.Now;
            await this.context.FindCombinationTaskRepository.UpdateAsync(task.Id, task, true);
        }
    }
}