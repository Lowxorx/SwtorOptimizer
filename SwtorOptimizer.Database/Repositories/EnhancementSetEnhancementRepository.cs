using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Database;

namespace SwtorOptimizer.Database.Repositories
{
    internal class EnhancementSetEnhancementRepository : BaseRespository<EnhancementSetEnhancement>
    {
        internal EnhancementSetEnhancementRepository(SwtorOptimizerContext dbContext) : base(dbContext)
        {
        }
    }
}