using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Models;

namespace SwtorOptimizer.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ISwtorOptimizerDatabaseService context;
        private readonly ILogger<AdminController> logger;

        public AdminController(ILogger<AdminController> logger, ISwtorOptimizerDatabaseService context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpPost]
        [ActionName(nameof(DeleteTask))]
        public IActionResult DeleteTask([FromBody] int taskId)
        {
            try
            {
                this.context.CalculationTaskRepository.Delete(taskId);
                return this.Ok(new ResultObject<string> { Message = $"La tâche {taskId} a été supprimée.", Data = null, StatusCode = 200 });
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, $"Impossible de supprimer la tâche {taskId}");
                return this.Problem(exception.Message);
            }
        }

        [HttpPost]
        [ActionName(nameof(StopTask))]
        public async Task<ActionResult> StopTask([FromBody] int taskId)
        {
            try
            {
                var task = this.context.CalculationTaskRepository.Get(taskId);
                task.Status = CalculationTaskStatus.Stopped;
                await this.context.CalculationTaskRepository.UpdateAsync(taskId, task, true);
                return this.Ok(new ResultObject<string> { Message = $"La tâche {taskId} a été stoppée. L'opération peut prendre jusqu'à 20 secondes.", Data = null, StatusCode = 200 });
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, $"Impossible de stopper la tâche {taskId}");
                return this.Problem(exception.Message);
            }
        }
    }
}