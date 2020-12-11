using System;
using System.Collections.Generic;
using System.Linq;
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

        public async void StartTask(CalculationTask task, List<GearPiece> enhancements)
        {
            this.logger.LogDebug($"Task {task.Id} is starting.");
            task.Status = CalculationTaskStatus.Started;
            task.StartDate = DateTime.Now;
            task.FoundSets = 0;
            await this.context.CalculationTaskRepository.UpdateAsync(task.Id, task, true);

            foreach (var combination in this.GetCombinations(enhancements, task.Threshold, string.Empty))
            {
                var newSetFound = combination.Split(' ').Select(result => enhancements.First(e => e.Id.Equals(Convert.ToInt32(result)))).ToList();

                var setName = string.Join(';', newSetFound.OrderBy(e => e.Name).Select(e => e.Name).ToArray());
                var setInternalName = string.Join(';', newSetFound.OrderBy(e => e.Id).Select(e => e.Id).ToArray());

                if (this.context.GearPieceSetRepository.All().FirstOrDefault(es => es.SetInternalName.Equals(setInternalName)) != null)
                {
                    continue;
                }

                var newSet = await this.context.GearPieceSetRepository.AddAsync(new GearPieceSet
                {
                    SetName = setName, 
                    SetInternalName = setInternalName, 
                    Threshold = task.Threshold, 
                    IsInvalid = false, 
                    CalculationTaskId = task.Id,
                    GearPieceCount = newSetFound.Count
                }, true);
                task.FoundSets++;
                var enhancementSetEnhancements = new List<GearPieceSetGearPiece>();
                enhancementSetEnhancements.AddRange(newSetFound.Select(e => new GearPieceSetGearPiece { GearPieceSetId = newSet.Id, GearPieceId = e.Id }));
                task.LastUpdate = DateTime.Now;
                var updatedTask = await this.context.CalculationTaskRepository.UpdateAsync(task.Id, task, true);
                await this.context.GearPieceSetGearPieceRepository.AddAllAsync(enhancementSetEnhancements);
                var reloadedTask = this.context.CalculationTaskRepository.Reload(updatedTask);
                if (reloadedTask.Status == CalculationTaskStatus.Stopped)
                {
                    break;
                }
            }

            if (task.FoundSets == 0)
            {
                await this.context.GearPieceSetRepository.AddAsync(new GearPieceSet
                {
                    SetName = "Invalid", 
                    Threshold = task.Threshold, 
                    IsInvalid = true, 
                    CalculationTaskId = task.Id,
                    GearPieceCount = 0
                }, true);
            }

            task.Status = CalculationTaskStatus.Ended;
            task.EndDate = DateTime.Now;
            this.logger.LogDebug($"Task {task.Id} is completed.");
            await this.context.CalculationTaskRepository.UpdateAsync(task.Id, task, true);
        }

        private IEnumerable<string> GetCombinations(IReadOnlyList<GearPiece> enhancements, int threshold, string values)
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