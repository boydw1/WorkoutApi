using WorkoutApi.Services;
using WorkoutApi.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkoutApi.Core.Configuration;
using WorkoutApi.Data;

namespace WorkoutApi
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _webHostEnvironment = environment;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppConfigurationOptions>(Configuration.GetSection("AppConfiguration"));
            //services.AddScoped<IWorkoutService, WorkoutService>();
            services.AddScoped<IDataService, DataService>();

            services.AddDbContext<WorkoutApiDbContext>(options =>
            {
                if (!_webHostEnvironment.IsProduction())
                {
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }

                var config = Configuration.GetSection("AppConfiguration").Get<AppConfigurationOptions>();

                options.UseSqlServer(config.SqlConnectionString);
            });

            services.AddControllers();            
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}