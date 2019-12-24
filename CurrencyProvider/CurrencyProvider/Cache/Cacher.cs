using System;
using System.Runtime.Caching;

namespace CurrencyProvider.Cache
{
    public class Cacher
        : ICacher
    {
        private readonly ObjectCache Cache = MemoryCache.Default;

        public void Add<T>(string key, T data, DateTimeOffset expiration)
        {
            if (Cache[key] == null)
            {
                //var opt = new CacheItemPolicy();
                //opt.SlidingExpiration = expiration == null ? TimeSpan.FromHours(12) : expiration;
                //Cache.Add(key, data, opt);

                Cache.Add(key, data, expiration);
            }
        }

        public void Clear(string name)
        {
            Cache.Remove(name);
        }

        public T Get<T>(string key)             
        {
            try
            {
                return (T)Cache[key];
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
