using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Database;

namespace SwtorOptimizer.Database.Repositories
{
    internal class EnhancementSetRepository : BaseRespository<EnhancementSet>
    {
        internal EnhancementSetRepository(SwtorOptimizerContext dbContext) : base(dbContext)
        {
        }
    }
}