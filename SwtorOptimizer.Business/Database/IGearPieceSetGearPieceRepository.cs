using System.Collections.Generic;
using System.Threading.Tasks;
using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Business.Database
{
    public interface IGearPieceSetGearPieceRepository : IRepository<GearPieceSetGearPiece>
    {
        void AddAll(IEnumerable<GearPieceSetGearPiece> gearPieceSetGearPieces);

        Task AddAllAsync(IEnumerable<GearPieceSetGearPiece> gearPieceSetGearPieces);
    }
}