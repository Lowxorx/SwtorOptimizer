using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Business.Database
{
    public interface ISwtorOptimizerDatabaseService
    {
        ICalculationTaskRepository CalculationTaskRepository { get; }
        IGearPieceRepository GearPieceRepository { get; }
        IGearPieceSetGearPieceRepository GearPieceSetGearPieceRepository { get; }
        IGearPieceSetRepository GearPieceSetRepository { get; }
        IRepository<Package> PackageRepository { get; }
        IRepository<User> UserRepository { get; }
    }
}