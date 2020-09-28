using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwtorOptimizer.Business.Database;

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
    }
}