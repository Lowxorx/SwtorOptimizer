using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwtorOptimizer.Database.Repositories
{
    internal class GearPieceSetGearPieceRepository : BaseRespository<GearPieceSetGearPiece>, IGearPieceSetGearPieceRepository
    {
        internal GearPieceSetGearPieceRepository(SwtorOptimizerContext dbContext) : base(dbContext)
        {
        }

        public void AddAll(IEnumerable<GearPieceSetGearPiece> gearPieceSetGearPieces)
        {
            foreach (var enhancementSetEnhancement in gearPieceSetGearPieces)
            {
                this.Add(enhancementSetEnhancement, false);
            }
            this.SaveChanges();
        }

        public async Task AddAllAsync(IEnumerable<GearPieceSetGearPiece> gearPieceSetGearPieces)
        {
            foreach (var enhancementSetEnhancement in gearPieceSetGearPieces)
            {
                await this.AddAsync(enhancementSetEnhancement, false);
            }

            await this.SaveChangesAsync();
        }
    }
}