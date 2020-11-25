using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Database;

namespace SwtorOptimizer.Database.Repositories
{
    internal class PackageRepository : BaseRespository<Package>
    {
        internal PackageRepository(SwtorOptimizerContext dbContext) : base(dbContext)
        {
        }
    }
}