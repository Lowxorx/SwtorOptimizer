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
                Tertiary = dto.Tertiary
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
                Tertiary = entity.Tertiary
            };
        }
    }
}