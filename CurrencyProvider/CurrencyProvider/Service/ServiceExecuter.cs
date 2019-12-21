using CurrencyProvider.Xml;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace CurrencyProvider.Service
{
    public class ServiceExecuter
        : IServiceExecuter
    {
        public string Endpoint { get; set; }

        public Dictionary<string, string> Header { get; set; }
        public Dictionary<string, string> Parameter { get; set; }

        public async Task<ServiceResponse<T>> InvokeGetAsync<T>(string path)
        {
            var result = new ServiceResponse<T>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    if (this.Header.Count > 0)
                    {
                        foreach (var kvp in this.Header)
                        {
                            httpClient.DefaultRequestHeaders.Add(kvp.Key, kvp.Value);
                        }
                    }

                    var queryUrl = string.Concat(this.Endpoint, path, buildEndpointRoute());

                    var response = await httpClient.GetAsync(queryUrl);
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();

                    result.Success = true;
                    result.Result = content.DeserializeXML<T>();
                }
            }
            catch
            {
                result.Success = false;
                result.Result = default(T);
            }

            this.Parameter.Clear();
            this.Header.Clear();

            return result;
        }

        private string buildEndpointRoute()
        {
            UriBuilder uriBuilder = new UriBuilder();
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            foreach (var urlParameter in this.Parameter)
            {
                query[urlParameter.Key] = urlParameter.Value;
            }

            uriBuilder.Query = query.ToString();
            return uriBuilder.Query;
        }
    }
}