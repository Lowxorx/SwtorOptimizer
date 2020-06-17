using SwtorOptimizer.Business.Entities;
using System.Collections.Generic;

namespace SwtorOptimizer.Business.Database
{
    public interface IEnhancementRepository : IRepository<Enhancement>
    {
        void AddAll(IEnumerable<Enhancement> enhancements);
    }
}