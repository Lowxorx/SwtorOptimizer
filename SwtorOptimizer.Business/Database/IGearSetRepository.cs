using System.Collections.Generic;
using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Business.Database
{
    public interface IGearSetRepository : IRepository<GearSet>
    {
        void AddAll(IEnumerable<GearSet> gearSets);
    }
}