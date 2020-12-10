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
        public async Task<IActionResult> GetGearSets()
        {
            var gearSets = await this.context.GearSetRepository.All().Include(e => e.GearSetGearPieces).ThenInclude(e => e.GearPiece).ToListAsync();
            return this.Ok(gearSets.Select(e => GearSetDtoConvertor.FromEntityToDto(e, e.GearSetGearPieces.Select(o => o.GearPiece).ToList())).ToList());
        }

        [HttpGet]
        [ActionName(nameof(GetGearSetsByTaskId))]
        public async Task<IActionResult> GetGearSetsByTaskId(int taskId)
        {
            var sets = await this.context.GearSetRepository.All().Where(e => e.CalculationTaskId == taskId).Include(e => e.GearSetGearPieces).ThenInclude(e => e.GearPiece).ToListAsync();
            if (sets.Any(e => e.IsInvalid))
            {
                return this.NoContent();
            }
            var dtos = sets.Select(e => GearSetDtoConvertor.FromEntityToDto(e, e.GearSetGearPieces.Select(o => o.GearPiece).ToList())).ToList();
            return this.Ok(dtos);
        }
    }
}