using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Api.DTOs;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Application.Interfaces
{
    public interface IExternalWheatherClient
    {
        Task<WeatherRecord> GetWeatherAsync(double lat, double lon);
    }
}
