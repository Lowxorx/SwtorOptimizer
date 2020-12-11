using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Database.Database;

namespace SwtorOptimizer.Database.Repositories
{
    internal class CalculationTaskRepository : BaseRespository<CalculationTask>, ICalculationTaskRepository
    {
        internal CalculationTaskRepository(SwtorOptimizerContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<CalculationTask>> GetAllCompletedTasks()
        {
            return await this.All().Where(e => e.Status == CalculationTaskStatus.Ended).ToListAsync();
        }

        public IQueryable<CalculationTask> GetAllWithGearPieceSets()
        {
            return this.All().Include(e => e.GearPieceSets).ThenInclude(e => e.GearPieceSetGearPieces).ThenInclude(e => e.GearPiece);
        }

        public async Task<CalculationTask> GetCompletedTaskDetails(int calculationTaskId)
        {
            return await this.All().Include(e => e.GearPieceSets).ThenInclude(e => e.GearPieceSetGearPieces).ThenInclude(e => e.GearPiece).FirstOrDefaultAsync(e => e.Id.Equals(calculationTaskId));
        }
    }
}