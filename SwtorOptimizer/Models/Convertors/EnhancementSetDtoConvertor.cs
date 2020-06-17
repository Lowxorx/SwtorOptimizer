using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Models.Dto;
using System.Collections.Generic;
using System.Linq;

namespace SwtorOptimizer.Models.Convertors
{
    public static class EnhancementSetDtoConvertor
    {
        public static EnhancementSet FromDtoToEntity(EnhancementSetDto dto)
        {
            return new EnhancementSet
            {
                Id = dto.Id,
                SetName = dto.SetName,
                Threshold = dto.Threshold,
                IsInvalid = dto.IsInvalid,
            };
        }

        public static EnhancementSetDto FromEntityToDto(EnhancementSet entity, List<Enhancement> enhancements)
        {
            return new EnhancementSetDto
            {
                Id = entity.Id,
                SetName = entity.SetName,
                Threshold = entity.Threshold,
                Power = enhancements?.Count > 0 ? enhancements.Sum(e => e.Power) : 0,
                IsInvalid = entity.IsInvalid,
                Enhancements = enhancements?.Count > 0 ? enhancements.Select(EnhancementDtoConvertor.FromEntityToDto).ToList() : null
            };
        }
    }
}