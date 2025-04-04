namespace PruebaJeissonR.Server.Models
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public T? Data { get; set; }
    }
}
