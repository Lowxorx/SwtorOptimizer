using System.Collections.Generic;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Database;

namespace SwtorOptimizer.Database.Repositories
{
    internal class GearSetRepository : BaseRespository<GearSet>, IGearSetRepository
    {
        internal GearSetRepository(SwtorOptimizerContext dbContext) : base(dbContext)
        {
        }

        public void AddAll(IEnumerable<GearSet> enhancementSets)
        {
            foreach (var enhancementSet in enhancementSets)
            {
                this.Add(enhancementSet, false);
            }
            this.SaveChanges();
        }
    }
}