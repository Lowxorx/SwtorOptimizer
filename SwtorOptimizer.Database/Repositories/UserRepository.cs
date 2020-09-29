using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Database;

namespace SwtorOptimizer.Database.Repositories
{
    internal class UserRepository : BaseRespository<User>
    {
        internal UserRepository(SwtorOptimizerContext dbContext) : base(dbContext)
        {
        }
    }
}