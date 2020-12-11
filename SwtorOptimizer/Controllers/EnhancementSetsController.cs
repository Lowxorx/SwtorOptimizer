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
            var enhancementSets = await this.context.GearPieceSetRepository.All().Include(e => e.GearPieceSetGearPieces).ThenInclude(e => e.GearPiece).ToListAsync();
            return this.Ok(enhancementSets.Select(e => GearPieceSetDtoConvertor.FromEntityToDto(e, e.GearPieceSetGearPieces.Select(e => e.GearPiece).ToList())).ToList());
        }

        [HttpGet]
        [ActionName(nameof(GetEnhancementSetsByTaskId))]
        public async Task<IActionResult> GetEnhancementSetsByTaskId(int taskId)
        {
            var sets = await this.context.GearPieceSetRepository.All().Where(e => e.CalculationTaskId == taskId).Include(e => e.GearPieceSetGearPieces).ThenInclude(e => e.GearPiece).ToListAsync();
            if (sets.Any(e => e.IsInvalid))
            {
                return this.NoContent();
            }
            var dtos = sets.Select(e => GearPieceSetDtoConvertor.FromEntityToDto(e, e.GearPieceSetGearPieces.Select(e => e.GearPiece).ToList())).ToList();
            return this.Ok(dtos);
        }
    }
}