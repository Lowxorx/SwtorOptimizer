using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwtorOptimizer.Business.Database;

namespace SwtorOptimizer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GearPiecesController : ControllerBase
    {
        private readonly ISwtorOptimizerDatabaseService context;
        private readonly ILogger<GearPiecesController> logger;

        public GearPiecesController(ILogger<GearPiecesController> logger, ISwtorOptimizerDatabaseService context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        [ActionName(nameof(GetGearPieces))]
        public async Task<IActionResult> GetGearPieces()
        {
            try
            {
                var gearPieces = await this.context.GearPieceRepository.All().ToListAsync();
                return this.Ok(gearPieces);
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erreur lors de la récupération des attributs");
            }
        }
    }
}