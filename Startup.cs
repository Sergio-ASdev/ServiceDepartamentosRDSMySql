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
using ServiceDepartamentosRDSMySql.Data;
using ServiceDepartamentosRDSMySql.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceDepartamentosRDSMySql
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            String cadena = Configuration.GetConnectionString("postgreslive");
            services.AddTransient<RepositoryCoches>();
            services.AddDbContext<CochesContext>(options => options.UseNpgsql(cadena));


            /*
            String cadenaaws = this.Configuration.GetConnectionString("awsmysqlhospital");

            services.AddTransient<RepositoryCoches>();
            services.AddDbContextPool<CochesContext>
                (options => options.UseMySql(
                    cadenaaws, ServerVersion.AutoDetect(cadenaaws)
                ));
            */

            //HABILITAMOS CORS EN EL SERVICIO
            services.AddCors(options => options.AddPolicy("AllowOrigin", c => c.AllowAnyOrigin()));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(name: "v1", new OpenApiInfo
                {
                    Title = "Api MySql AWS",
                    Version = "v1",
                    Description = "Api MySql AWS"
                });
            });
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.AllowAnyOrigin());
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(
                url: "/swagger/v1/swagger.json", name: "Api v1");
                options.RoutePrefix = "";
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
