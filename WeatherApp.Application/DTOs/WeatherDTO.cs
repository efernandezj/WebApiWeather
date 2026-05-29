namespace WeatherApp.Api.DTOs
{
    public class WeatherDto
    {
        public double Tempeture { get; set; }
        public double WindDirection { get; set; }
        public float WindSpeed { get; set; }
        public string[] SunriseDateTime { get; set; }
    }
}
