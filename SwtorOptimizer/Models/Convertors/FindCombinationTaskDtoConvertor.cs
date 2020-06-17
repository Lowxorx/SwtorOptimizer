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
                IsFaulted = dto.IsFaulted,
                IsRunning = dto.IsRunning,
                IsStarted = dto.IsStarted,
                IsEnded = dto.IsEnded,
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
                IsFaulted = entity.IsFaulted,
                IsRunning = entity.IsRunning,
                IsStarted = entity.IsStarted,
                IsEnded = entity.IsEnded,
                StartDate = entity.StartDate,
                Threshold = entity.Threshold,
                FoundSets = entity.FoundSets,
                EnhancementSetDtos = enhancementSets?.Select(e => EnhancementSetDtoConvertor.FromEntityToDto(e, null)).ToList()
            };
        }
    }
}