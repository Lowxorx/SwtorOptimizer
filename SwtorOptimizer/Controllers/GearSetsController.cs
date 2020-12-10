using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Models.Convertors;

namespace SwtorOptimizer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GearSetsController : ControllerBase
    {
        private readonly ISwtorOptimizerDatabaseService context;
        private readonly ILogger<GearSetsController> logger;

        public GearSetsController(ILogger<GearSetsController> logger, ISwtorOptimizerDatabaseService context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEnhancementSets()
        {
            var enhancementSets = await this.context.GearSetRepository.All().Include(e => e.GearSetGearPieces).ThenInclude(e => e.GearPiece).ToListAsync();
            return this.Ok(enhancementSets.Select(e => GearSetDtoConvertor.FromEntityToDto(e, e.GearSetGearPieces.Select(e => e.GearPiece).ToList())).ToList());
        }

        [HttpGet]
        [ActionName(nameof(GetEnhancementSetsByTaskId))]
        public async Task<IActionResult> GetEnhancementSetsByTaskId(int taskId)
        {
            var sets = await this.context.GearSetRepository.All().Where(e => e.CalculationTaskId == taskId).Include(e => e.GearSetGearPieces).ThenInclude(e => e.GearPiece).ToListAsync();
            if (sets.Any(e => e.IsInvalid))
            {
                return this.NoContent();
            }
            var dtos = sets.Select(e => GearSetDtoConvertor.FromEntityToDto(e, e.GearSetGearPieces.Select(e => e.GearPiece).ToList())).ToList();
            return this.Ok(dtos);
        }
    }
}