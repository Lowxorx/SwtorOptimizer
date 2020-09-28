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
            return this.Ok(enhancementSets.Select(e => EnhancementSetDtoConvertor.FromEntityToDto(e, e.EnhancementSetEnhancements.Select(e => e.Enhancement).ToList())).ToList());
        }

        [HttpGet]
        [ActionName(nameof(GetEnhancementSetsByTaskId))]
        public async Task<IActionResult> GetEnhancementSetsByTaskId(int taskId)
        {
            var sets = await this.context.EnhancementSetRepository.All().Where(e => e.CalculationTaskId == taskId).Include(e => e.EnhancementSetEnhancements).ThenInclude(e => e.Enhancement).ToListAsync();
            if (sets.Any(e => e.IsInvalid))
            {
                return this.NoContent();
            }
            var dtos = sets.Select(e => EnhancementSetDtoConvertor.FromEntityToDto(e, e.EnhancementSetEnhancements.Select(e => e.Enhancement).ToList())).ToList();
            return this.Ok(dtos);
        }
    }
}