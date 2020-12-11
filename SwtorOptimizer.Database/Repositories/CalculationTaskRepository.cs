using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Database;

namespace SwtorOptimizer.Database.Repositories
{
    internal class CalculationTaskRepository : BaseRespository<CalculationTask>
    {
        internal CalculationTaskRepository(SwtorOptimizerContext dbContext) : base(dbContext)
        {
        }
    }
}