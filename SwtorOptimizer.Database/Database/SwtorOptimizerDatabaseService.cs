using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Repositories;

namespace SwtorOptimizer.Database.Database
{
    public class SwtorOptimizerDatabaseService : ISwtorOptimizerDatabaseService
    {
        public SwtorOptimizerDatabaseService(string connectionString)
        {
            this.DbContext = new SwtorOptimizerContext(connectionString);
            DbInitializer.Initialize(this.DbContext);
        }

        public IEnhancementRepository EnhancementRepository => new EnhancementRepository(this.DbContext);

        public IRepository<EnhancementSetEnhancement> EnhancementSetEnhancementRepository => new EnhancementSetEnhancementRepository(this.DbContext);

        public IRepository<EnhancementSet> EnhancementSetRepository => new EnhancementSetRepository(this.DbContext);

        public IRepository<FindCombinationTask> FindCombinationTaskRepository => new FindCombinationTaskRepository(this.DbContext);

        private SwtorOptimizerContext DbContext { get; }
    }
}