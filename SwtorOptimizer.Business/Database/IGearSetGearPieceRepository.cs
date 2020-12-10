using System.Collections.Generic;
using System.Threading.Tasks;
using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Business.Database
{
    public interface IGearSetGearPieceRepository : IRepository<GearSetGearPiece>
    {
        void AddAll(IEnumerable<GearSetGearPiece> enhancementSetEnhancements);

        Task AddAllAsync(IEnumerable<GearSetGearPiece> enhancementSetEnhancements);
    }
}