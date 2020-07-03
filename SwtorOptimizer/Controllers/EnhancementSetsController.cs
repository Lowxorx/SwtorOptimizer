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

namespace SwtorOptimizer.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnhancementSetsController : ControllerBase
    {
        private readonly ISwtorOptimizerDatabaseService context;
        private readonly ILogger<EnhancementSetsController> logger;

        public EnhancementSetsController(ILogger<EnhancementSetsController> logger, ISwtorOptimizerDatabaseService context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEnhancementSets()
        {
            var enhancementSets = await this.context.EnhancementSetRepository.All().Include(e => e.EnhancementSetEnhancements).ThenInclude(e => e.Enhancement).ToListAsync();
            return Ok(enhancementSets.Select(e => EnhancementSetDtoConvertor.FromEntityToDto(e, e.EnhancementSetEnhancements.Select(e => e.Enhancement).ToList())).ToList());
        }

        [HttpGet]
        [ActionName(nameof(GetEnhancementSetsForThreshold))]
        public async Task<IActionResult> GetEnhancementSetsForThreshold(int threshold)
        {
            var sets = await this.context.EnhancementSetRepository.All().Where(e => e.Threshold == threshold).Include(e => e.EnhancementSetEnhancements).ThenInclude(e => e.Enhancement).ToListAsync();
            if (sets.Any(e => e.IsInvalid))
            {
                return this.NoContent();
            }
            var dtos = sets.Select(e => EnhancementSetDtoConvertor.FromEntityToDto(e, e.EnhancementSetEnhancements.Select(e => e.Enhancement).ToList())).ToList();
            return this.Ok(dtos);
        }

        [HttpGet]
        [ActionName(nameof(GetNewEnhancementSet))]
        public async Task<IActionResult> GetNewEnhancementSet(int threshold)
        {
            if (!this.context.EnhancementSetRepository.All().Any(e => e.Threshold == threshold))
            {
                var newTask = await this.context.FindCombinationTaskRepository.AddAsync(new FindCombinationTask { Threshold = threshold, IsRunning = false, IsFaulted = false, IsEnded = false, IsStarted = false, FoundSets = 0 }, true);
                return this.Accepted(new ResultObject<string> { StatusCode = StatusCodes.Status202Accepted, Message = "Une tâche a été crée." });
            }
            return this.Ok(new ResultObject<string> { StatusCode = StatusCodes.Status200OK, Message = "Le calcul a déjà été effectué." });
        }
    }
}