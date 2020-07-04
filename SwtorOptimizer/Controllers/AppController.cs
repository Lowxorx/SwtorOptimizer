using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace SwtorOptimizer.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetComponentsVersion()
        {
            return Ok(LogComponentVersions());
        }

        private List<string> LogComponentVersions()
        {
            var versions = new List<string>();

            var businessDllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SwtorOptimizer.Business.dll");
            var databaseDllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SwtorOptimizer.Database.dll");

            versions.Add($"Optimizer v.{ FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion }");

            if (System.IO.File.Exists(businessDllPath))
            {
                var fileVersion = FileVersionInfo.GetVersionInfo(businessDllPath);
                versions.Add($"Business v.{fileVersion.FileVersion}");
            }

            if (System.IO.File.Exists(databaseDllPath))
            {
                var fileVersion = FileVersionInfo.GetVersionInfo(databaseDllPath);
                versions.Add($"Database v.{fileVersion.FileVersion}");
            }

            return versions;
        }
    }
}