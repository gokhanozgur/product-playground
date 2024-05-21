using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProductPlayground.Application.Interfaces.RedisCache;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Infrastructure.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly ConnectionMultiplexer redisConnnection;
        private readonly IDatabase database;
        private readonly RedisCacheSettings redisCachesettings;

        public RedisCacheService(IOptions<RedisCacheSettings> options)
        {
            redisCachesettings = options.Value;
            var opt = ConfigurationOptions.Parse(redisCachesettings.ConnectionString);
            redisConnnection = ConnectionMultiplexer.Connect(opt);
            database = redisConnnection.GetDatabase();
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await database.StringGetAsync(key);
            if (value.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }

        public async Task SetAsync<T>(string key, T value, DateTime? expirationTime = null)
        {
            TimeSpan timeUntilExpiration = expirationTime.Value - DateTime.Now;
            await database.StringSetAsync(key, JsonConvert.SerializeObject(value), timeUntilExpiration);
        }
    }
}
