using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwtorOptimizer.Database.Repositories
{
    internal class GearSetGearPieceRepository : BaseRespository<GearSetGearPiece>, IGearSetGearPieceRepository
    {
        internal GearSetGearPieceRepository(SwtorOptimizerContext dbContext) : base(dbContext)
        {
        }

        public void AddAll(IEnumerable<GearSetGearPiece> enhancementSetEnhancements)
        {
            foreach (var enhancementSetEnhancement in enhancementSetEnhancements)
            {
                this.Add(enhancementSetEnhancement, false);
            }
            this.SaveChanges();
        }

        public async Task AddAllAsync(IEnumerable<GearSetGearPiece> enhancementSetEnhancements)
        {
            foreach (var enhancementSetEnhancement in enhancementSetEnhancements)
            {
                await this.AddAsync(enhancementSetEnhancement, false);
            }

            await this.SaveChangesAsync();
        }
    }
}