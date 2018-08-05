using StackExchange.Redis;
using System;

namespace CachingWithReflection.Helpers
{
    public class RedisHelper
    {
        private ConnectionMultiplexer _redis;

        public RedisHelper()
        {
            Initialize();
        }

        private void Initialize()
        {
            _redis = ConnectionMultiplexer.Connect("localhost");
        }

        public void Cache(string key, string value, TimeSpan expiration)
        {
            var db = _redis.GetDatabase();
            db.StringSet(key, value, expiration);
        }

        public string GetValue(string key)
        {
            var db = _redis.GetDatabase();
            var result = db.StringGet(key);
            if (result.HasValue)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
