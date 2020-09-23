using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Models.Dto;

namespace SwtorOptimizer.Models.Convertors
{
    public static class EnhancementDtoConvertor
    {
        public static Enhancement FromDtoToEntity(EnhancementDto dto)
        {
            return new Enhancement
            {
                Id = dto.Id,
                Name = dto.Name,
                Endurance = dto.Endurance,
                Power = dto.Power,
                Tertiary = dto.Tertiary,
                CriticalName = dto.CriticalName,
                AccuracyName = dto.AccuracyName,
                AlacrityName = dto.AlacrityName
            };
        }

        public static EnhancementDto FromEntityToDto(Enhancement entity)
        {
            return new EnhancementDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Endurance = entity.Endurance,
                Power = entity.Power,
                Tertiary = entity.Tertiary,
                CriticalName = entity.CriticalName,
                AccuracyName = entity.AccuracyName,
                AlacrityName = entity.AlacrityName
            };
        }
    }
}