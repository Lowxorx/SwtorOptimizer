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

        public void AddAll(IEnumerable<GearSetGearPiece> gearSetGearPieces)
        {
            foreach (var gearSetGearPiece in gearSetGearPieces)
            {
                this.Add(gearSetGearPiece, false);
            }
            this.SaveChanges();
        }

        public async Task AddAllAsync(IEnumerable<GearSetGearPiece> gearSetGearPieces)
        {
            foreach (var gearSetGearPiece in gearSetGearPieces)
            {
                await this.AddAsync(gearSetGearPiece, false);
            }

            await this.SaveChangesAsync();
        }
    }
}