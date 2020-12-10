using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Models.Dto;

namespace SwtorOptimizer.Models.Convertors
{
    public static class GearPieceDtoConvertor
    {
        public static GearPieceDto FromEntityToDto(GearPiece entity)
        {
            return new GearPieceDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Endurance = entity.Endurance,
                Power = entity.Power,
                Tertiary = entity.Tertiary,
                Mastery = entity.Mastery
            };
        }
    }
}