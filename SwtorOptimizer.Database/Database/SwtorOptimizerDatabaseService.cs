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

        private SwtorOptimizerContext DbContext { get; }

        public ICalculationTaskRepository CalculationTaskRepository => new CalculationTaskRepository(this.DbContext);
        public IGearPieceRepository GearPieceRepository => new GearPieceRepository(this.DbContext);
        public IGearPieceSetGearPieceRepository GearPieceSetGearPieceRepository => new GearPieceSetGearPieceRepository(this.DbContext);
        public IGearPieceSetRepository GearPieceSetRepository => new GearPieceSetRepository(this.DbContext);
        public IRepository<Package> PackageRepository => new PackageRepository(this.DbContext);
        public IRepository<User> UserRepository => new UserRepository(this.DbContext);
    }
}