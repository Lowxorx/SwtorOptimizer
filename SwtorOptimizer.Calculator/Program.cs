﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Calculator.Workers;
using SwtorOptimizer.Database.Database;
using System;
using System.IO;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.SystemConsole.Themes;
using System.Text;
using SwtorOptimizer.Business.Settings;

namespace SwtorOptimizer.Calculator
{
    public static class Program
    {
        private static readonly Action<IConfigurationBuilder> BuildConfiguration = builder => builder
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddEnvironmentVariables()
        .AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"appsettings.{Environment.GetEnvironmentVariable("APP_ENV")}.json"), false, true);

        public static void Main(string[] args)
        {
            const string loggerTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u4}]<{ThreadId}> [{SourceContext:l}] {Message:lj}{NewLine}{Exception}";
            var logfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "SwtorOptimizer.Calculator.log");

            var builder = new ConfigurationBuilder();
            builder.AddCommandLine(args);
            BuildConfiguration(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .Enrich.WithThreadId()
                .Enrich.WithThreadName()
                .Enrich.WithExceptionDetails()
                .WriteTo.Console(outputTemplate: loggerTemplate, theme: AnsiConsoleTheme.Literate)
                .WriteTo.File(logfile, outputTemplate: loggerTemplate, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 90, encoding: Encoding.UTF8)
                .CreateLogger();

            try
            {
                Log.Information("====================================================================");
                Log.Information($"SWTOR OPTIMIZER Calculator service is starting. Version: {System.Reflection.Assembly.GetEntryAssembly()?.GetName().Version}");
                Log.Information($"Service location : {AppDomain.CurrentDomain.BaseDirectory}");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "SWTOR OPTIMIZER Calculator service terminated unexpectedly");
            }
            finally
            {
                Log.Information("====================================================================");
                Log.CloseAndFlush();
            }
        }

        private static string BuildConnectionString(string connectionString)
        {
            Log.Information("Building connection string");
            connectionString = connectionString.Replace("#DBPASSWORD#", Environment.GetEnvironmentVariable("DB_PASSWORD"));
            connectionString = connectionString.Replace("#DBSERVER#", Environment.GetEnvironmentVariable("DB_SERVER"));
            connectionString = connectionString.Replace("#DBNAME#", Environment.GetEnvironmentVariable("DB_NAME"));
            connectionString = connectionString.Replace("#DBUSER#", Environment.GetEnvironmentVariable("DB_USER"));
            return connectionString;
        }

        private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureHostConfiguration(BuildConfiguration)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddHostedService<SetCalculatorWorker>();
            services.Configure<DatabaseSettings>(hostContext.Configuration.GetSection(nameof(DatabaseSettings)));
            services.AddTransient<ISwtorOptimizerDatabaseService>(_ => new SwtorOptimizerDatabaseService(BuildConnectionString(hostContext.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"))));
        })
        .UseSerilog();
    }
}