using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Models.Dto;
using System.Collections.Generic;
using System.Linq;

namespace SwtorOptimizer.Models.Convertors
{
    public static class CalculationTaskDtoConvertor
    {
        public static CalculationTaskDto FromEntityToDto(CalculationTask entity, List<GearPieceSet> gearPieceSets)
        {
            return new CalculationTaskDto
            {
                Id = entity.Id,
                EndDate = entity.EndDate,
                Status = (int)entity.Status,
                StartDate = entity.StartDate,
                Threshold = entity.Threshold,
                FoundSets = entity.FoundSets,
                GearPieceSets = gearPieceSets?.Select(e => GearPieceSetDtoConvertor.FromEntityToDto(e, null)).ToList()
            };
        }
    }
}