using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwtorOptimizer.Database.Repositories
{
    internal class EnhancementSetEnhancementRepository : BaseRespository<EnhancementSetEnhancement>, IEnhancementSetEnhancementRepository
    {
        internal EnhancementSetEnhancementRepository(SwtorOptimizerContext dbContext) : base(dbContext)
        {
        }

        public void AddAll(IEnumerable<EnhancementSetEnhancement> enhancementSetEnhancements)
        {
            foreach (var enhancementSetEnhancement in enhancementSetEnhancements)
            {
                this.Add(enhancementSetEnhancement, false);
            }
            this.SaveChanges();
        }

        public async Task AddAllAsync(IEnumerable<EnhancementSetEnhancement> enhancementSetEnhancements)
        {
            foreach (var enhancementSetEnhancement in enhancementSetEnhancements)
            {
                await this.AddAsync(enhancementSetEnhancement, false);
            }

            await this.SaveChangesAsync();
        }
    }
}