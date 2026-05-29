using Microsoft.AspNetCore.Mvc;
using WeatherApp.Application.Interfaces;



namespace WeatherApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _wheatherService;


    public WeatherController(IWeatherService serviceService)
    {
        _wheatherService = serviceService;
    }

    [HttpGet("coordinates")]
    public async Task<IActionResult> GetByCoordinates([FromQuery] double lat, [FromQuery] double lon)
    {
        try
        {
            var response = await _wheatherService.GetWheatherByCoordinatesAsync(lat, lon);
            return Ok(response);

        }
        catch (HttpRequestException ex)
        {
            return StatusCode(StatusCodes.Status503ServiceUnavailable,
                new { error = "External Service no available", detail = ex.Message });

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { error = "Internal Server Error", detail = ex.Message });
        }
    }

}
