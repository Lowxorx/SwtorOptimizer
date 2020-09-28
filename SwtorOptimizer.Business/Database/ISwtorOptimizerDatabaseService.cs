using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Business.Database
{
    public interface ISwtorOptimizerDatabaseService
    {
        IRepository<CalculationTask> CalculationTaskRepository { get; }
        IEnhancementRepository EnhancementRepository { get; }
        IEnhancementSetEnhancementRepository EnhancementSetEnhancementRepository { get; }
        IEnhancementSetRepository EnhancementSetRepository { get; }
        IRepository<User> UserRepository { get; }
    }
}