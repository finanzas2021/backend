using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finanzas.API.Domain.Repositories;
using Finanzas.API.Domain.Respositories;
using Finanzas.API.Domain.Services;
using Finanzas.API.Persistence.Contexts;
using Finanzas.API.Persistence.Repositories;
using Finanzas.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Finanzas.API
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
            services.AddControllers();
            
            services.AddRouting(options => options.LowercaseUrls = true);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Finanzas.API", Version = "v1"});
                c.EnableAnnotations();
            });
            
            // Configure In-Memory Database
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("finanzas-api-in-memory");
            });
            
            // Dependency Injection Rules
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICarteraRepository,CarteraRepository>();
            services.AddScoped<ICarteraService, CarteraService>();
            services.AddScoped<IHistorialRepository, HistorialRepository>();
            services.AddScoped<IHistorialService,HistorialService>();
            services.AddScoped<IReciboRepository, ReciboRepository>();
            services.AddScoped<IReciboService, ReciboService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // AutoMapper Dependency Injection
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Finanzas.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}