using InternationalCitySearch.Api.Middleware;
using InternationalCitySearch.Core.DataInterface;
using InternationalCitySearch.Core.Processor;
using InternationalCitySearch.DataAccess;
using InternationalCitySearch.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
//using Serilog;

namespace InternationalCitySearch.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(
        this WebApplicationBuilder builder)
        {
            // AddSwagger(builder.Services);
            builder.Services.AddScoped<ICitySearchRequestProcessor, CitySearchRequestProcessor>();
            builder.Services.AddDataAccessServices(builder.Configuration);
            builder.Services.AddMemoryCache();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            return builder.Build();

        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GloboTicket Ticket Management API");
                });
            }

            app.UseHttpsRedirection();
            
            app.UseAuthentication();

            app.UseCustomExceptionHandler();

            app.UseCors("Open");

            app.UseAuthorization();

            app.MapControllers();

            return app;

        }
        // add swagger config
    }
}