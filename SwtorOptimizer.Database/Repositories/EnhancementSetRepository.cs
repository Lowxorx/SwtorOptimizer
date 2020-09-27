using System.Collections.Generic;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Database;

namespace SwtorOptimizer.Database.Repositories
{
    internal class EnhancementSetRepository : BaseRespository<EnhancementSet>, IEnhancementSetRepository
    {
        internal EnhancementSetRepository(SwtorOptimizerContext dbContext) : base(dbContext)
        {
        }

        public void AddAll(IEnumerable<EnhancementSet> enhancementSets)
        {
            foreach (var enhancementSet in enhancementSets)
            {
                this.Add(enhancementSet, false);
            }
            this.SaveChanges();
        }
    }
}