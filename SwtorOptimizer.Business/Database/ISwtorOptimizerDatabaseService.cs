using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Business.Database
{
    public interface ISwtorOptimizerDatabaseService
    {
        IEnhancementRepository EnhancementRepository { get; }
        IEnhancementSetEnhancementRepository EnhancementSetEnhancementRepository { get; }
        IEnhancementSetRepository EnhancementSetRepository { get; }
        IRepository<FindCombinationTask> FindCombinationTaskRepository { get; }
    }
}