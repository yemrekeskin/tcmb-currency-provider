using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyProvider.Cache
{
    public interface ICacher
    {
        T Get<T>(string name);

        T Add<T>(string name, T data);

        void Clear(string name);
    }
}
