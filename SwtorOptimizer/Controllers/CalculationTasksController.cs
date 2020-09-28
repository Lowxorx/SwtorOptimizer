using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Models.Convertors;

namespace SwtorOptimizer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculationTasksController : ControllerBase
    {
        private readonly ISwtorOptimizerDatabaseService context;
        private readonly ILogger<CalculationTasksController> logger;

        public CalculationTasksController(ILogger<CalculationTasksController> logger, ISwtorOptimizerDatabaseService context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await this.context.CalculationTaskRepository.All().ToListAsync();
            var tasksDto = tasks.Select(task => CalculationTaskDtoConvertor.FromEntityToDto(task, null)).ToList();
            this.logger.LogDebug($"Return {tasksDto.Count} tasks");
            return this.Ok(tasksDto);
        }

        [HttpGet]
        [ActionName(nameof(GetTaskById))]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await this.context.CalculationTaskRepository.All().FirstOrDefaultAsync(e => e.Id == id);
            if (task != null)
            {
                return this.Ok(CalculationTaskDtoConvertor.FromEntityToDto(task, null));
            }
            return this.NoContent();
        }

        [HttpGet]
        [ActionName(nameof(GetTaskForThreshold))]
        public async Task<IActionResult> GetTaskForThreshold(int threshold)
        {
            var task = await this.context.CalculationTaskRepository.All().Where(e => e.Threshold == threshold).FirstOrDefaultAsync();
            var sets = await this.context.EnhancementSetRepository.All().Where(e => e.Threshold == threshold).ToListAsync();

            if (task == null)
            {
                return this.StatusCode(StatusCodes.Status204NoContent);
            }

            return this.Ok(CalculationTaskDtoConvertor.FromEntityToDto(task, sets));
        }
    }
}