using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog.Extensions.Logging;
using SqlServer;
using Contracts;

namespace HireIntelligence
{
    public class Startup
    {
        public static IConfiguration StaticConfig { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfig = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddNLog());
            AddStorage(services);

            var hireIntelligenceAppAddress = Configuration.GetValue<string>(
            "HireIntelligenceApp:Address");
            services.AddCors(options =>
            {
                options.AddPolicy("HireIntelligenceAppPolicy",
                    builder =>
                    {
                        builder.WithOrigins(hireIntelligenceAppAddress);
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });

            services.AddControllers();
        }

        private void AddStorage(IServiceCollection services)
        {
            AddSqlEngine(services);
            services.AddTransient<IStorageManager, SqlManager>();
        }

        private void AddSqlEngine(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("HireIntelligenceDbConnectionString");
            services.AddSingleton<IStorageEngine>(sqlEngine=> new SqlEngine(connectionString));
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

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
