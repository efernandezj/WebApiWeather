using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Application.Interfaces;
using WeatherApp.Application.Services;
using WeatherApp.Infrastructure.Clients;
using WeatherApp.Infrastructure.Repositories;
using WeatherApp.Infrastructure.Settings;


namespace WeatherApp.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDBSettings>(configuration.GetSection("MongoDB"));
            services.AddHttpClient<OpenMeteoWheatherClient>();
            services.AddScoped<IWeatherService, WeaterService>();
            services.AddScoped<IExternalWheatherClient, OpenMeteoWheatherClient>();
            services.AddSingleton<IWeatherRepository, WeatherMongoRepository>();


            return services;
        }
    }
}
