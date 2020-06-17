using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SwtorOptimizer.Business.Database;
using System;
using System.Threading.Tasks;

namespace SwtorOptimizer.API.Controllers
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
                var enhancements = await this.context.EnhancementRepository.All().ToListAsync();
                return this.Ok(enhancements);
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erreur lors de la récupération des attributs");
            }
        }
    }
}