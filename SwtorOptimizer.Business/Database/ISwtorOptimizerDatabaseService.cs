using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Business.Database
{
    public interface ISwtorOptimizerDatabaseService
    {
        IRepository<CalculationTask> CalculationTaskRepository { get; }
        IGearPieceRepository GearPieceRepository { get; }
        IGearSetGearPieceRepository GearSetGearPieceRepository { get; }
        IGearSetRepository GearSetRepository { get; }
        IRepository<User> UserRepository { get; }
    }
}