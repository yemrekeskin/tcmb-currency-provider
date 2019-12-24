using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyProvider.Cache
{
    public interface ICacher
    {
        T Get<T>(string key);
        void Add<T>(string key, T data, DateTimeOffset expiration);
        void Clear(string key); 
    }
}
