using RestSharp;

namespace AccesoDatos.Interfaces
{
    public interface IApiService
    {
        /// <summary>
        /// Envia una peticion http
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="parametros"></param>
        /// <param name="method"></param>
        /// <param name="body"></param>
        /// <param name="timeoutEnSegundos"></param>
        /// <returns></returns>
        Task<RestResponse<T>> SendRequestAsync<T>(string url, List<RestSharp.Parameter>? parametros = null,
            Method method = Method.Get, object? body = null, int timeoutEnSegundos = 60);
    }
}
