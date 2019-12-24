using Microsoft.Extensions.Caching.Memory;
using System;

namespace CurrencyProvider.Cache
{
    public class Cacher
        : ICacher
    {
        private MemoryCache MemoryCache { get; set; }

        public T Add<T>(string name, T data, TimeSpan? expiration)
        {
            T cached;
            if (!MemoryCache.TryGetValue<T>(name, out cached))
            {
                cached = data;

                var opt = new MemoryCacheEntryOptions();
                opt.SlidingExpiration = expiration == null ? TimeSpan.FromHours(12) : expiration;

                MemoryCache.Set(name, cached, opt);
            }

            return cached;
        }

        public void Clear(string name)
        {
            MemoryCache.Remove(name);
        }

        public T Get<T>(string name)
        {
            T cached;
            MemoryCache.TryGetValue<T>(name, out cached);
            return cached;
        }
    }
}
