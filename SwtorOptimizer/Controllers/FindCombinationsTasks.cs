using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Models.Convertors;
using SwtorOptimizer.Models.Dto;

namespace SwtorOptimizer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FindCombinationsTasks : ControllerBase
    {
        private readonly ISwtorOptimizerDatabaseService context;
        private readonly ILogger<FindCombinationsTasks> logger;

        public FindCombinationsTasks(ILogger<FindCombinationsTasks> logger, ISwtorOptimizerDatabaseService context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await this.context.FindCombinationTaskRepository.All().ToListAsync();
            var tasksDto = tasks.Select(task => FindCombinationTaskDtoConvertor.FromEntityToDto(task, null)).ToList();
            return this.Ok(tasksDto);
        }

        [HttpGet]
        [ActionName(nameof(GetTaskById))]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await this.context.FindCombinationTaskRepository.All().FirstOrDefaultAsync(e => e.Id == id);
            if (task != null)
            {
                return this.Ok(FindCombinationTaskDtoConvertor.FromEntityToDto(task, null));
            }
            return this.NoContent();
        }

        [HttpGet]
        [ActionName(nameof(GetTaskForThreshold))]
        public async Task<IActionResult> GetTaskForThreshold(int threshold)
        {
            var task = await this.context.FindCombinationTaskRepository.All().Where(e => e.Threshold == threshold).FirstOrDefaultAsync();
            var sets = await this.context.EnhancementSetRepository.All().Where(e => e.Threshold == threshold).ToListAsync();

            if (task == null)
            {
                return this.StatusCode(StatusCodes.Status204NoContent);
            }

            return this.Ok(FindCombinationTaskDtoConvertor.FromEntityToDto(task, sets));
        }
    }
}