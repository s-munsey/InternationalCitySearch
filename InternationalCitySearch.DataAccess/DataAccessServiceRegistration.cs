using InternationalCitySearch.Core.DataInterface;
using InternationalCitySearch.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InternationalCitySearch.DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CitySearchDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CityDBConnectionString")));

            services.AddScoped<ICitiesRepository, CitiesRepository>();

            return services;
        }
    }
}
