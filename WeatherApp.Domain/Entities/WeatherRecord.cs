using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WeatherApp.Domain.Entities
{
    public class WeatherRecord
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Timezone { get; set; }
        public string Timezone_abbreviation { get; set; }
        public CurrentWheaterUnits Current_weather_units { get; set; }
        public CurrentWheater Current_weather { get; set; }
        public Daily Daily { get; set; }
    }

    public class CurrentWheaterUnits
    {
        public string Time { get; set; }
        public string Interval { get; set; }
        public string Temperature { get; set; }
        public string Windspeed { get; set; }
        public string Winddirection { get; set; }
    }

    public class CurrentWheater
    {
        public string Time { get; set; }
        public int Interval { get; set; }
        public float Temperature { get; set; }
        public float Windspeed { get; set; }
        public int Winddirection { get; set; }

    }

    public class Daily
    {
        public string[] Sunrise { get; set; }
    }
}
