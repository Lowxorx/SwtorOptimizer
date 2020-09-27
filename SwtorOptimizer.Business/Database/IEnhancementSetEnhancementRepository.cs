using System.Collections.Generic;
using System.Threading.Tasks;
using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Business.Database
{
    public interface IEnhancementSetEnhancementRepository : IRepository<EnhancementSetEnhancement>
    {
        void AddAll(IEnumerable<EnhancementSetEnhancement> enhancementSetEnhancements);

        Task AddAllAsync(IEnumerable<EnhancementSetEnhancement> enhancementSetEnhancements);
    }
}