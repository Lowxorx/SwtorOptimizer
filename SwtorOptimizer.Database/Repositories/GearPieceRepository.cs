using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Database;
using System.Collections.Generic;

namespace SwtorOptimizer.Database.Repositories
{
    internal class GearPieceRepository : BaseRespository<GearPiece>, IGearPieceRepository
    {
        internal GearPieceRepository(SwtorOptimizerContext dbContext) : base(dbContext)
        {
        }

        public void AddAll(IEnumerable<GearPiece> gearPieces)
        {
            foreach (var enhancement in gearPieces)
            {
                this.Add(enhancement, false);
            }
            this.SaveChanges();
        }
    }
}