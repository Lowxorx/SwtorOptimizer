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

        public async void StartTask(CalculationTask task, List<GearPiece> gearPieces)
        {
            this.logger.LogDebug($"Task {task.Id} is starting.");
            task.Status = CalculationTaskStatus.Started;
            task.StartDate = DateTime.Now;
            task.FoundSets = 0;
            await this.context.CalculationTaskRepository.UpdateAsync(task.Id, task, true);

            foreach (var combination in this.GetCombinations(gearPieces, task.Threshold, string.Empty))
            {
                var newSetFound = combination.Split(' ').Select(result => gearPieces.First(e => e.Id.Equals(Convert.ToInt32(result)))).ToList();

                var setName = string.Join(';', newSetFound.OrderBy(e => e.Name).Select(e => e.Name).ToArray());
                var setInternalName = string.Join(';', newSetFound.OrderBy(e => e.Id).Select(e => e.Id).ToArray());

                if (this.context.GearSetRepository.All().FirstOrDefault(es => es.SetInternalName.Equals(setInternalName)) != null)
                {
                    continue;
                }

                var newSet = await this.context.GearSetRepository.AddAsync(new GearSet { SetName = setName, SetInternalName = setInternalName, Threshold = task.Threshold, IsInvalid = false, CalculationTaskId = task.Id }, true);
                task.FoundSets++;
                var enhancementSetEnhancements = new List<GearSetGearPiece>();
                enhancementSetEnhancements.AddRange(newSetFound.Select(e => new GearSetGearPiece { GearSetId = newSet.Id, GearPieceId = e.Id }));
                task.LastUpdate = DateTime.Now;
                var updatedTask = await this.context.CalculationTaskRepository.UpdateAsync(task.Id, task, true);
                await this.context.GearSetGearPieceRepository.AddAllAsync(enhancementSetEnhancements);
                var reloadedTask = this.context.CalculationTaskRepository.Reload(updatedTask);
                if (reloadedTask.Status == CalculationTaskStatus.Stopped)
                {
                    break;
                }
            }

            if (task.FoundSets == 0)
            {
                await this.context.GearSetRepository.AddAsync(new GearSet { SetName = "Invalid", Threshold = task.Threshold, IsInvalid = true, CalculationTaskId = task.Id }, true);
            }

            task.Status = CalculationTaskStatus.Ended;
            task.EndDate = DateTime.Now;
            this.logger.LogDebug($"Task {task.Id} is completed.");
            await this.context.CalculationTaskRepository.UpdateAsync(task.Id, task, true);
        }

        private IEnumerable<string> GetCombinations(IReadOnlyList<GearPiece> gearPieces, int threshold, string values)
        {
            foreach (var baseGear in gearPieces)
            {
                var left = threshold - baseGear.Tertiary;
                if (left < 0)
                {
                    continue;
                }
                var vals = baseGear.Id + " " + values;
                if (left == 0)
                {
                    yield return vals.Trim();
                }
                else
                {
                    foreach (var s in this.GetCombinations(gearPieces, left, vals))
                    {
                        yield return s.Trim();
                    }
                }
            }
        }
    }
}