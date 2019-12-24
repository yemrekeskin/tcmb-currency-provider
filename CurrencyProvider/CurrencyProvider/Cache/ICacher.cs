using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyProvider.Cache
{
    public interface ICacher
    {
        T Get<T>(string name);
        T Add<T>(string name, T data, TimeSpan? expiration);
        void Clear(string name);
    }
}
