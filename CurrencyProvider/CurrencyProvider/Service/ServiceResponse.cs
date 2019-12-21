using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyProvider.Service
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; } = default(T);
    }
}
