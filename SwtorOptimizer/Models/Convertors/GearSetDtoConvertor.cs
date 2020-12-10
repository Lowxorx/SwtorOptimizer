using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Models.Dto;
using System.Collections.Generic;
using System.Linq;

namespace SwtorOptimizer.Models.Convertors
{
    public static class EnhancementSetDtoConvertor
    {
        public static EnhancementSetDto FromEntityToDto(GearSet entity, List<GearPiece> enhancements)
        {
            return new EnhancementSetDto
            {
                Id = entity.Id,
                SetName = entity.SetName,
                Threshold = entity.Threshold,
                Power = enhancements?.Count > 0 ? enhancements.Sum(e => e.Power) : 0,
                Endurance = enhancements?.Count > 0 ? enhancements.Sum(e => e.Endurance) : 0,
                IsInvalid = entity.IsInvalid,
                Enhancements = enhancements?.Count > 0 ? enhancements.Select(GearPieceDtoConvertor.FromEntityToDto).ToList() : null,
                CalculationTaskId = entity.CalculationTaskId,
                CalculationTask = entity.CalculationTask != null ? CalculationTaskDtoConvertor.FromEntityToDto(entity.CalculationTask, null) : null
            };
        }
    }
}