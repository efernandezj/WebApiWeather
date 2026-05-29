using System.Text.Json;
using WeatherApp.Api.DTOs;
using WeatherApp.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using WeatherApp.Domain.Entities;


namespace WeatherApp.Infrastructure.Clients
{

    public class OpenMeteoWheatherClient : IExternalWheatherClient
    {
        private readonly HttpClient _httpClient;

        public OpenMeteoWheatherClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(config["OpenMeteo:BaseUrl"]);
        }

        public async Task<WeatherRecord> GetWeatherAsync(double lat, double lon)
        {
            var url = $"?latitude={lat}&longitude={lon}&daily=sunrise&current_weather=true&timezone=auto&hourly=&current=temperature_2m,wind_speed_10m,wind_direction_10m#location_and_time";
            var response = await _httpClient.GetAsync(url);


            var json = await response.Content.ReadAsStringAsync();
            var dto = JsonSerializer.Deserialize<WeatherRecord>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return dto!;
        }
    }

}
