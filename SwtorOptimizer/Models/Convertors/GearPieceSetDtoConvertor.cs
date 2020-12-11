using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Models.Dto;
using System.Collections.Generic;
using System.Linq;

namespace SwtorOptimizer.Models.Convertors
{
    public static class GearPieceSetDtoConvertor
    {
        public static GearPieceSetDto FromEntityToDto(GearPieceSet entity, List<GearPiece> gearPieces)
        {
            return new GearPieceSetDto
            {
                Id = entity.Id,
                SetName = entity.SetName,
                Threshold = entity.Threshold,
                Power = gearPieces?.Count > 0 ? gearPieces.Sum(e => e.Power) : 0,
                Endurance = gearPieces?.Count > 0 ? gearPieces.Sum(e => e.Endurance) : 0,
                IsInvalid = entity.IsInvalid,
                GearPieces = gearPieces?.Count > 0 ? gearPieces.Select(GearPieceDtoConvertor.FromEntityToDto).ToList() : null,
                CalculationTaskId = entity.CalculationTaskId,
                GearPieceCount = entity.GearPieceCount,
                CalculationTask = entity.CalculationTask != null ? CalculationTaskDtoConvertor.FromEntityToDto(entity.CalculationTask, null) : null
            };
        }
    }
}