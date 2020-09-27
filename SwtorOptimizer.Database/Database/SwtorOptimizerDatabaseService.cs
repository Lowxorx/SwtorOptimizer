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

        public IEnhancementSetEnhancementRepository EnhancementSetEnhancementRepository => new EnhancementSetEnhancementRepository(this.DbContext);

        public IEnhancementSetRepository EnhancementSetRepository => new EnhancementSetRepository(this.DbContext);

        public IRepository<FindCombinationTask> FindCombinationTaskRepository => new FindCombinationTaskRepository(this.DbContext);

        private SwtorOptimizerContext DbContext { get; }
    }
}