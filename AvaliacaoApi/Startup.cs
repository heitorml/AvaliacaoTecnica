using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaliacaoApi.Business;
using AvaliacaoApi.Business.Interfaces;
using AvaliacaoApi.Data;
using AvaliacaoApi.Data.Interfaces;
using AvaliacaoApi.Models.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AvaliacaoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddCors(options =>
          {
              options.AddPolicy("AllowCredentials", builder =>
                  builder.WithOrigins(Configuration.GetSection("CORSPermission").GetSection("origins").Value)
                  .AllowCredentials()
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  );
          });
            services.AddSingleton<IJogoBusiness, JogoBusiness>();
            services.AddScoped<ISistemaData, SistemaData>();

            services.AddScoped<ISistemaBusiness, SistemaBusiness>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("AllowCredentials");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
