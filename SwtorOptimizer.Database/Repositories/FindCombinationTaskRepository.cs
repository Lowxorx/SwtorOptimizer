using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Database;

namespace SwtorOptimizer.Database.Repositories
{
    internal class FindCombinationTaskRepository : BaseRespository<FindCombinationTask>
    {
        internal FindCombinationTaskRepository(SwtorOptimizerContext dbContext) : base(dbContext)
        {
        }
    }
}