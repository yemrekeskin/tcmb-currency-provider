﻿using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text;

namespace CurrencyProvider.Cache
{
    public class Cacher
        : ICacher
    {
        private MemoryCache MemoryCache { get; set; }

        public T Add<T>(string name, T data)
        {
            T cached;
            if (!MemoryCache.TryGetValue<T>(name, out cached))
            {
                cached = data;

                var opt = new MemoryCacheEntryOptions();
                opt.SlidingExpiration = TimeSpan.FromHours(12);

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
