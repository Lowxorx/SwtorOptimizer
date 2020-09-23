using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Models.Dto;
using System.Collections.Generic;
using System.Linq;

namespace SwtorOptimizer.Models.Convertors
{
    public static class FindCombinationTaskDtoConvertor
    {
        public static FindCombinationTask FromDtoToEntity(FindCombinationTaskDto dto)
        {
            return new FindCombinationTask
            {
                Id = dto.Id,
                EndDate = dto.EndDate,
                Status = (FindCombinationTaskStatus)dto.Status,
                StartDate = dto.StartDate,
                Threshold = dto.Threshold,
                FoundSets = dto.FoundSets
            };
        }

        public static FindCombinationTaskDto FromEntityToDto(FindCombinationTask entity, List<EnhancementSet> enhancementSets)
        {
            return new FindCombinationTaskDto
            {
                Id = entity.Id,
                EndDate = entity.EndDate,
                Status = (int)entity.Status,
                StartDate = entity.StartDate,
                Threshold = entity.Threshold,
                FoundSets = entity.FoundSets,
                EnhancementSetDtos = enhancementSets?.Select(e => EnhancementSetDtoConvertor.FromEntityToDto(e, null)).ToList()
            };
        }
    }
}