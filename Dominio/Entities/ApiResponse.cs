using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    /// <summary>
    /// respuesta de dummy api
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        public string? Status { get; set; }
        public T? Data { get; set; }
    }
}
