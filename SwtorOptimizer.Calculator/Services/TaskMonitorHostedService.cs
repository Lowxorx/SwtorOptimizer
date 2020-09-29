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
        private List<Enhancement> enhancements;

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
            this.enhancements = this.context.EnhancementRepository.All().ToList();
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
            var allTasks = new List<CalculationTask>();

            try
            {
                allTasks = await this.context.CalculationTaskRepository.All().ToListAsync();
            }
            catch (Exception e)
            {
                this.logger.LogError(e, $"Cannot get all tasks. Error : {e.Message}");
            }

            // Cleanup current faulted tasks
            var runningTasks = allTasks.Where(e => e.Status == CalculationTaskStatus.Started).ToList();
            if (runningTasks.Count == 0)
            {
                this.logger.LogDebug($"No task to clean.");
            }
            else
            {
                foreach (var task in runningTasks.Where(task => DateTime.Now.Subtract(task.LastUpdate).Minutes >= 5))
                {
                    this.logger.LogWarning($"A task seems to hang (task #{task.Id}). Cleaning...");
                    task.Status = CalculationTaskStatus.Faulted;
                    task.EndDate = DateTime.Now;
                    await this.context.CalculationTaskRepository.UpdateAsync(task.Id, task, true);
                }
            }

            // Launch new tasks
            var waitingTasks = allTasks.Where(e => e.Status == CalculationTaskStatus.Idle).ToList();
            if (waitingTasks.Count == 0)
            {
                this.logger.LogDebug($"No task to run. Standby for {this.settings.Value.TaskInterval} seconds... ");
                return;
            }
            this.logger.LogInformation($"Let's launch {waitingTasks.Count} task(s) !");
            foreach (var task in waitingTasks)
            {
                using var scope = this.Services.CreateScope();
                var scopedProcessingService = scope.ServiceProvider.GetRequiredService<ISetCalculatorProcessingService>();
                scopedProcessingService.StartTask(task, this.enhancements);
            }
        }
    }
}