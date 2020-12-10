using System.Collections.Generic;
using System.Threading.Tasks;
using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Business.Database
{
    public interface IGearSetGearPieceRepository : IRepository<GearSetGearPiece>
    {
        void AddAll(IEnumerable<GearSetGearPiece> gearSetGearPieces);

        Task AddAllAsync(IEnumerable<GearSetGearPiece> gearSetGearPieces);
    }
}