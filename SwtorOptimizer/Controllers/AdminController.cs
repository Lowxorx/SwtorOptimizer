using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwtorOptimizer.Business.Database;
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
                return this.Problem(exception.Message);
            }
        }
    }
}