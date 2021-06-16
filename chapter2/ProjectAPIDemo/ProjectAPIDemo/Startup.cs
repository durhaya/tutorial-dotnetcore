using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ProjectAPIDemo
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
            // services.AddControllers();
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectAPIDemo", Version = "v1" });
            // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectAPIDemo v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/tickets", async context=>{
                    await context.Response.WriteAsync("Reading all tickets");
                });
                endpoints.MapGet("/tickets/{id:int}", async context => {
                    var routeData = context.GetRouteData().Values;
                    var ticketId = routeData["id"] as string;
                    
                    await context.Response.WriteAsync($"Reading ticket # {ticketId}");
                });

                endpoints.MapPost("/tickets", async context => {
                    await context.Response.WriteAsync("Creating a ticket");
                });

                endpoints.MapPut("/tickets/{id:int}", async context => {
                    var routeData = context.GetRouteData().Values;
                    var ticketId = routeData["id"] as string;

                    await context.Response.WriteAsync($"Updating ticket # {ticketId}");
                });

                endpoints.MapDelete("/tickets/{id:int}", async context => {
                    var routeData = context.GetRouteData().Values;
                    var ticketId = routeData["id"] as string;

                    await context.Response.WriteAsync($"Deleting a ticket # {ticketId}");
                });

                // endpoints.MapControllers();
            });
        }
    }
}
