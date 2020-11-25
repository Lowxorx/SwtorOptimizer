﻿using SwtorOptimizer.Business.Database;
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
        public IEnhancementRepository EnhancementRepository => new EnhancementRepository(this.DbContext);
        public IEnhancementSetEnhancementRepository EnhancementSetEnhancementRepository => new EnhancementSetEnhancementRepository(this.DbContext);
        public IEnhancementSetRepository EnhancementSetRepository => new EnhancementSetRepository(this.DbContext);
        public IRepository<Package> PackageRepository => new PackageRepository(this.DbContext);
        public IRepository<User> UserRepository => new UserRepository(this.DbContext);
        private SwtorOptimizerContext DbContext { get; }
    }
}