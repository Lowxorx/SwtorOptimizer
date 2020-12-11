using System.Collections.Generic;
using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Business.Database
{
    public interface IGearPieceSetRepository : IRepository<GearPieceSet>
    {
        void AddAll(IEnumerable<GearPieceSet> gearPieceSets);
    }
}