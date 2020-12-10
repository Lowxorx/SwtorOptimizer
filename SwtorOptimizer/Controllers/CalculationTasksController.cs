using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Models;
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
        [ActionName(nameof(CalculateGearSets))]
        public async Task<IActionResult> CalculateGearSets(int threshold)
        {
            var existingCalculationTask = await this.context.GearSetRepository.All().FirstOrDefaultAsync(e => e.Threshold == threshold);
            if (existingCalculationTask != null)
            {
                return this.Ok(new ResultObject<int> { StatusCode = StatusCodes.Status200OK, Message = "Le calcul a déjà été effectué.", Data = existingCalculationTask.CalculationTaskId });
            }

            var newTask = await this.context.CalculationTaskRepository.AddAsync(new CalculationTask { Threshold = threshold, Status = CalculationTaskStatus.Idle, FoundSets = 0 }, true);
            return this.Accepted(new ResultObject<int> { StatusCode = StatusCodes.Status202Accepted, Message = "Une tâche a été crée.", Data = newTask.Id });
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
        [ActionName(nameof(GetTaskDetails))]
        public async Task<IActionResult> GetTaskDetails(int id)
        {
            var task = await this.context.CalculationTaskRepository.All().Where(e => e.Id == id).FirstOrDefaultAsync();
            var sets = await this.context.GearSetRepository.All().Where(e => e.CalculationTaskId == id).ToListAsync();

            if (task == null)
            {
                return this.StatusCode(StatusCodes.Status204NoContent);
            }

            return this.Ok(CalculationTaskDtoConvertor.FromEntityToDto(task, sets));
        }
    }
}