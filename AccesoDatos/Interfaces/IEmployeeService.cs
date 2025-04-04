using Dominio.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Obtener todos los empleados mediante un webservice
        /// </summary>
        /// <returns></returns>
        Task<RestResponse<ApiResponse<List<Employee>>>> GetAllAsync();

        /// <summary>
        /// obtiene un empleado por id mediante un webservice
        /// </summary>
        /// <param name="id">id empleado</param>
        /// <returns>empleado si hay si no null</returns>
        Task<RestResponse<ApiResponse<Employee?>>> GetByIdAsync(int id);
    }
}
