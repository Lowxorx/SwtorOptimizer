using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Entities;
using SwtorOptimizer.Calculator.Settings;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SwtorOptimizer.Calculator.Services
{
    internal class TaskMonitorHostedService : IHostedService
    {
        private readonly ISwtorOptimizerDatabaseService context;
        private readonly ILogger<TaskMonitorHostedService> logger;
        private readonly IOptions<CalculatorSettings> settings;

        public TaskMonitorHostedService(IServiceProvider services, ILogger<TaskMonitorHostedService> logger, IOptions<CalculatorSettings> settings, ISwtorOptimizerDatabaseService context)
        {
            this.Services = services;
            this.logger = logger;
            this.settings = settings;
            this.context = context;
        }

        private IServiceProvider Services { get; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("TaskMonitorHostedService is starting.");

            while (!cancellationToken.IsCancellationRequested)
            {
                await this.CheckAndStartTasks();
                await Task.Delay(TimeSpan.FromSeconds(this.settings.Value.TaskInterval), cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("TaskMonitorHostedService is stopping.");
            return Task.CompletedTask;
        }

        private async Task CheckAndStartTasks()
        {
            var tasks = new List<CalculationTask>();

            try
            {
                tasks = await this.context.CalculationTaskRepository.All().Where(e => e.EndDate == default && e.Status == CalculationTaskStatus.Idle).ToListAsync();
            }
            catch (Exception e)
            {
                this.logger.LogError(e, $"Task error : {e.Message}");
            }

            if (tasks.Count == 0)
            {
                this.logger.LogDebug($"No task found. Standby for {this.settings.Value.TaskInterval} seconds... ");
                return;
            }

            this.logger.LogInformation($"We have a job to do. Let's launch {tasks.Count} task(s)");
            var enhancements = this.context.EnhancementRepository.All().ToList();

            foreach (var task in tasks)
            {
                using var scope = this.Services.CreateScope();
                var scopedProcessingService = scope.ServiceProvider.GetRequiredService<ISetCalculatorProcessingService>();
                scopedProcessingService.StartTask(task, enhancements);
            }
        }
    }
}