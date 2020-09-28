using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Models.Dto;

namespace SwtorOptimizer.Models.Convertors
{
    public static class EnhancementDtoConvertor
    {
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