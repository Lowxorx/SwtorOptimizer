using System.Collections.Generic;
using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Business.Database
{
    public interface IEnhancementSetRepository : IRepository<EnhancementSet>
    {
        void AddAll(IEnumerable<EnhancementSet> enhancementSets);
    }
}