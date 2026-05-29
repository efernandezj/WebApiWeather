using Microsoft.Extensions.Options;
using WeatherApp.Api.DTOs;
using MongoDB.Driver;
using WeatherApp.Infrastructure.Settings;
using WeatherApp.Application.Interfaces;
using WeatherApp.Domain.Entities;
using MongoDB.Bson;


namespace WeatherApp.Infrastructure.Repositories
{
    public class WeatherMongoRepository : IWeatherRepository
    {
        private readonly IMongoCollection<WeatherRecord> _collection;

        public WeatherMongoRepository(IOptions<MongoDBSettings> mongoSettings)
        {
            var settings = mongoSettings.Value;
            var client = new MongoClient(settings.ConnectionURI);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<WeatherRecord>(settings.CollectionName);
        }

        public async Task<WeatherRecord> GetWheatherByCoordinatesAsync(double lat, double lon)
        {
            var filter =
                Builders<WeatherRecord>.Filter.Eq(x => x.Latitude, lat) &
                Builders<WeatherRecord>.Filter.Eq(x => x.Longitude, lon);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(WeatherRecord weather)
        {
            var filter =
                Builders<WeatherRecord>.Filter.Eq(x => x.Latitude, weather.Latitude) &
                Builders<WeatherRecord>.Filter.Eq(x => x.Longitude, weather.Longitude);

            var existing = await _collection.Find(filter).FirstOrDefaultAsync();

            if (existing == null)
            {
                await _collection.InsertOneAsync(weather);
            }
            else
            {
                weather.Id = existing.Id;
                await _collection.ReplaceOneAsync(filter, weather);
            }
        }
    }


}
