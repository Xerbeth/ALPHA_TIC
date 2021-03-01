using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.AlphaTIC.Services;
using Domain.AlphaTIC.Services.Implementation;
using Domain.AlphaTIC.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace AlphaTIC.API
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<IDocumentTypeServices, DocumentTypeServices>();
            StartupServices.ConfigureServices(services, connectionString);

            services.AddControllers();

            #region Swagger
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"AlphaTIC {groupName}",
                    Version = groupName,
                    Description = "AlphaTIC API",
                    Contact = new OpenApiContact
                    {
                        Name = "Xerbeth",
                        Email = "faiber.torres.o@gmail.com",
                        Url = new Uri("https://github.com/Xerbeth/ALPHA_TIC"),
                    }
                });
            });
            #endregion Swagger
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });
            #endregion Swagger

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
