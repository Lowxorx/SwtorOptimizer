using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Calculator.Services;
using SwtorOptimizer.Calculator.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using System.Threading.Tasks;

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

        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Starting SetCalculatorWorker service...");
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Run(this.CheckAndStartTasks, cancellationToken);
                await Task.Delay(TimeSpan.FromSeconds(this.settings.Value.TaskInterval), cancellationToken);
            }
        }

        private void CheckAndStartTasks()
        {
            var tasks = this.context.FindCombinationTaskRepository.All().Where(e => e.EndDate == default && e.Status == FindCombinationTaskStatus.Idle).ToList();
            if (tasks.Count == 0) return;

            this.logger.LogInformation($"We have a job to do. Let's launch {tasks.Count} job");
            var enhancements = this.context.EnhancementRepository.All().ToList();

            foreach (var task in tasks)
            {
                Task.Run(() => this.StartTask(task, enhancements)).ContinueWith((result) =>
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

        private void StartTask(FindCombinationTask task, List<Enhancement> enhancements)
        {
            task.Status = FindCombinationTaskStatus.Started;
            task.StartDate = DateTime.Now;
            task.FoundSets = 0;
            this.context.FindCombinationTaskRepository.Update(task.Id, task, true);

            var calculator = new SetCalculatorService(task.Threshold, enhancements);
            var combinations = calculator.Calculate();

            if (combinations.Count == 0)
            {
                this.context.EnhancementSetRepository.Add(new EnhancementSet { SetName = "Invalid", Threshold = task.Threshold, IsInvalid = true }, true);
            }
            else
            {
                var enhancementSetEnhancements = new List<EnhancementSetEnhancement>();

                foreach (var combination in combinations)
                {
                    var newSetFound = combination.Split(' ').Select(result => enhancements.First(e => e.Id.Equals(Convert.ToInt32(result)))).ToList();

                    var setName = string.Join(';', newSetFound.OrderBy(e => e.Name).Select(e => e.Name).ToArray());

                    if (this.context.EnhancementSetRepository.All().FirstOrDefault(es => es.SetName.Equals(setName)) != null) continue;

                    var newSet = this.context.EnhancementSetRepository.Add(new EnhancementSet { SetName = setName, Threshold = task.Threshold, IsInvalid = false }, true);
                    task.FoundSets++;

                    enhancementSetEnhancements.AddRange(newSetFound.Select(e => new EnhancementSetEnhancement { EnhancementSetId = newSet.Id, EnhancementId = e.Id }));
                }
                this.context.FindCombinationTaskRepository.Update(task.Id, task, true);

                foreach (var e in enhancementSetEnhancements)
                {
                    this.context.EnhancementSetEnhancementRepository.Add(e, false);
                }
                this.context.EnhancementSetEnhancementRepository.SaveChanges();
            }

            task.Status = FindCombinationTaskStatus.Ended;
            task.EndDate = DateTime.Now;
            this.context.FindCombinationTaskRepository.Update(task.Id, task, true);
        }
    }
}