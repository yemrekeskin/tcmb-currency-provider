using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProvider.Service
{
    public interface IServiceExecuter
    {
        string Endpoint { get; set; }
        ResponseType ResponseType { get; set; }

        Dictionary<string, string> Header { get; set; }
        Dictionary<string, string> Parameter { get; set; }

        Task<ServiceResponse<T>> InvokeGetAsync<T>(string path);
        ServiceResponse<T> InvokeGet<T>(string path);
    }
}
