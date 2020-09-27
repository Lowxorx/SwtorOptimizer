using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Calculator.Services
{
    internal class SetCalculatorProcessingService : ISetCalculatorProcessingService
    {
        private readonly ISwtorOptimizerDatabaseService context;
        private readonly ILogger<SetCalculatorProcessingService> logger;

        public SetCalculatorProcessingService(ILogger<SetCalculatorProcessingService> logger, ISwtorOptimizerDatabaseService context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async void StartTask(FindCombinationTask task, List<Enhancement> enhancements)
        {
            this.logger.LogDebug($"Task {task.Id} is starting.");
            task.Status = FindCombinationTaskStatus.Started;
            task.StartDate = DateTime.Now;
            task.FoundSets = 0;
            await this.context.FindCombinationTaskRepository.UpdateAsync(task.Id, task, true);

            foreach (var combination in this.GetCombinations(enhancements, task.Threshold, string.Empty))
            {
                var newSetFound = combination.Split(' ').Select(result => enhancements.First(e => e.Id.Equals(Convert.ToInt32(result)))).ToList();

                var setName = string.Join(';', newSetFound.OrderBy(e => e.Name).Select(e => e.Name).ToArray());
                var setInternalName = string.Join(';', newSetFound.OrderBy(e => e.Id).Select(e => e.Id).ToArray());

                if (this.context.EnhancementSetRepository.All().FirstOrDefault(es => es.SetInternalName.Equals(setInternalName)) != null) continue;

                var newSet = await this.context.EnhancementSetRepository.AddAsync(new EnhancementSet { SetName = setName, SetInternalName = setInternalName, Threshold = task.Threshold, IsInvalid = false }, true);
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
            this.logger.LogDebug($"Task {task.Id} is completed.");
            await this.context.FindCombinationTaskRepository.UpdateAsync(task.Id, task, true);
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
    }
}