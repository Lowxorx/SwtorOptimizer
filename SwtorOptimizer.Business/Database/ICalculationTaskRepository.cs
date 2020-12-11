using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Business.Database
{
    public interface ICalculationTaskRepository : IRepository<CalculationTask>
    {
        Task<IEnumerable<CalculationTask>> GetAllCompletedTasks();
        IQueryable<CalculationTask> GetAllWithGearPieceSets();
        Task<CalculationTask> GetCompletedTaskDetails(int calculationTaskId);
    }
}