using SwtorOptimizer.Business.Entities;
using System.Collections.Generic;

namespace SwtorOptimizer.Business.Database
{
    public interface IGearPieceRepository : IRepository<GearPiece>
    {
        void AddAll(IEnumerable<GearPiece> enhancements);
    }
}