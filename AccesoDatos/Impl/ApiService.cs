using AccesoDatos.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Impl
{
    public class ApiService : IApiService
    {
        public async Task<RestResponse<T>> SendRequestAsync<T>(string url, List<Parameter>? parametros = null,
            Method method = Method.Get, object? body = null, int timeoutEnSegundos = 60)
        {
            var options = new RestClientOptions(url)
            {
                ThrowOnAnyError = false,
                Timeout = TimeSpan.FromMilliseconds(timeoutEnSegundos * 1000)
            };

            var client = new RestClient(options);
            var request = new RestRequest();

            request.Method = method;

            if (parametros != null)
            {
                foreach (var param in parametros)
                {
                    request.AddParameter(param);
                }
            }

            if (body != null && (method == Method.Post || method == Method.Put))
            {
                request.AddJsonBody(body);
            }

            RestResponse<T> response = await client.ExecuteAsync<T>(request);
            return response;
        }
    }
}
