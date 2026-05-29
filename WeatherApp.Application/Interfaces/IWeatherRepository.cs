using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Api.DTOs;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Application.Interfaces
{
    public interface IWeatherRepository
    {
        Task<WeatherRecord> GetWheatherByCoordinatesAsync(double lat, double lon);
        Task SaveAsync(WeatherRecord wheather);
    }
}
