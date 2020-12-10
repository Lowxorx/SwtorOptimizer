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

        public IRepository<CalculationTask> CalculationTaskRepository => new CalculationTaskRepository(this.DbContext);
        public IGearPieceRepository GearPieceRepository => new GearPieceRepository(this.DbContext);
        public IGearSetGearPieceRepository GearSetGearPieceRepository => new GearSetGearPieceRepository(this.DbContext);
        public IGearSetRepository GearSetRepository => new GearSetRepository(this.DbContext);
        public IRepository<User> UserRepository => new UserRepository(this.DbContext);
        private SwtorOptimizerContext DbContext { get; }
    }
}