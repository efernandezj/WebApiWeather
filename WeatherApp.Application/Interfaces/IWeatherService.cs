using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Api.DTOs;

namespace WeatherApp.Application.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetWheatherByCoordinatesAsync(double lat, double lon);
    }

}
