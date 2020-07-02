using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Business.Settings;
using SwtorOptimizer.Database.Database;
using System;

namespace SwtorOptimizer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(options =>
                {
                    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseCors();

                // The default HSTS value is 30 days. You may want to change this for production
                // scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core, see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            this.ConfigureDatabase(services);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/dist");
        }

        private static string BuildConnectionString(string connectionString)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development") return connectionString;
            connectionString = connectionString.Replace("#DBPASSWORD#", Environment.GetEnvironmentVariable("DB_PASSWORD"));
            connectionString = connectionString.Replace("#DBSERVER#", Environment.GetEnvironmentVariable("DB_SERVER"));
            connectionString = connectionString.Replace("#DBNAME#", Environment.GetEnvironmentVariable("DB_NAME"));
            connectionString = connectionString.Replace("#DBUSER#", Environment.GetEnvironmentVariable("DB_USER"));
            return connectionString;
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            services.Configure<DatabaseSettings>(this.Configuration.GetSection(nameof(DatabaseSettings)));
            services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
            services.AddTransient<ISwtorOptimizerDatabaseService>(a => new SwtorOptimizerDatabaseService(BuildConnectionString(this.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"))));
        }
    }
}