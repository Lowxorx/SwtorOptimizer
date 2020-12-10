using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Models.Dto;
using System.Collections.Generic;
using System.Linq;

namespace SwtorOptimizer.Models.Convertors
{
    public static class GearSetDtoConvertor
    {
        public static GearSetDto FromEntityToDto(GearSet entity, List<GearPiece> gearPieces)
        {
            return new GearSetDto
            {
                Id = entity.Id,
                SetName = entity.SetName,
                Threshold = entity.Threshold,
                Power = gearPieces?.Count > 0 ? gearPieces.Sum(e => e.Power) : 0,
                Endurance = gearPieces?.Count > 0 ? gearPieces.Sum(e => e.Endurance) : 0,
                IsInvalid = entity.IsInvalid,
                GearPieces = gearPieces?.Count > 0 ? gearPieces.Select(GearPieceDtoConvertor.FromEntityToDto).ToList() : null,
                CalculationTaskId = entity.CalculationTaskId,
                CalculationTask = entity.CalculationTask != null ? CalculationTaskDtoConvertor.FromEntityToDto(entity.CalculationTask, null) : null
            };
        }
    }
}