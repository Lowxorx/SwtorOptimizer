using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Database;
using System.Collections.Generic;

namespace SwtorOptimizer.Database.Repositories
{
    internal class EnhancementRepository : BaseRespository<Enhancement>, IEnhancementRepository
    {
        internal EnhancementRepository(SwtorOptimizerContext dbContext) : base(dbContext)
        {
        }

        public void AddAll(IEnumerable<Enhancement> enhancements)
        {
            foreach (var enhancement in enhancements)
            {
                this.Add(enhancement, false);
            }
            this.SaveChanges();
        }
    }
}