using WeatherApp.Api.DTOs;
using WeatherApp.Application.Interfaces;
using WeatherApp.Domain.Entities;





namespace WeatherApp.Application.Services;

public class WeaterService : IWeatherService
{
    private readonly IWeatherRepository _localMongoRepository;
    private readonly IExternalWheatherClient _externalWheatherClient;

    public WeaterService(IWeatherRepository localMongoRepository, IExternalWheatherClient externalWheatherClient)
    {
        this._localMongoRepository = localMongoRepository;
        this._externalWheatherClient = externalWheatherClient;
    }

    public async Task<WeatherDto> GetWheatherByCoordinatesAsync(double lat, double lon)
    {
        var localData = await _localMongoRepository.GetWheatherByCoordinatesAsync(lat, lon);
        if (localData != null) return MapToDto(localData);

        
        var externalData = await _externalWheatherClient.GetWeatherAsync(lat, lon);
        await _localMongoRepository.SaveAsync(externalData);
        return MapToDto(externalData);
    }


    private static WeatherDto MapToDto(WeatherRecord record)
    {
        return new WeatherDto
        {
            Tempeture = record.Current_weather.Temperature,
            WindDirection = record.Current_weather.Winddirection,
            WindSpeed = record.Current_weather.Windspeed,
            SunriseDateTime = record.Daily.Sunrise
        };
    }
}




