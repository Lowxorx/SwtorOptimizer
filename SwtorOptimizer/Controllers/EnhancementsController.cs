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
    public class EnhancementsController : ControllerBase
    {
        private readonly ISwtorOptimizerDatabaseService context;
        private readonly ILogger<EnhancementsController> logger;

        public EnhancementsController(ILogger<EnhancementsController> logger, ISwtorOptimizerDatabaseService context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        [ActionName(nameof(GetEnhancements))]
        public async Task<IActionResult> GetEnhancements()
        {
            try
            {
                var enhancements = await this.context.GearPieceRepository.All().ToListAsync();
                return this.Ok(enhancements);
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erreur lors de la r�cup�ration des attributs");
            }
        }
    }
}