using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace SwtorOptimizer
{
    public static class Program
    {
        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
            .AddEnvironmentVariables()
            .Build();

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Debug()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
                .CreateLogger();

            try
            {
                Log.Information("Getting the server running...");
                LogComponentVersions();

                var host = CreateHostBuilder(args).Build();
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).UseSerilog().ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

        private static void LogComponentVersions()
        {
            var businessDllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SwtorOptimizer.Business.dll");
            var databaseDllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SwtorOptimizer.Database.dll");

            Log.Information($"SWTOR Optimizer version { FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion }");

            if (File.Exists(businessDllPath))
            {
                var fileVersion = FileVersionInfo.GetVersionInfo(businessDllPath);
                Log.Information($"SWTOR Business component version: {fileVersion.FileVersion}");
            }

            if (File.Exists(databaseDllPath))
            {
                var fileVersion = FileVersionInfo.GetVersionInfo(databaseDllPath);
                Log.Information($"SWTOR Database component version: {fileVersion.FileVersion}");
            }
        }
    }
}