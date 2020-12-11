using System.Collections.Generic;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Database;

namespace SwtorOptimizer.Database.Repositories
{
    internal class GearPieceSetRepository : BaseRespository<GearPieceSet>, IGearPieceSetRepository
    {
        internal GearPieceSetRepository(SwtorOptimizerContext dbContext) : base(dbContext)
        {
        }

        public void AddAll(IEnumerable<GearPieceSet> gearPieceSets)
        {
            foreach (var enhancementSet in gearPieceSets)
            {
                this.Add(enhancementSet, false);
            }
            this.SaveChanges();
        }
    }
}