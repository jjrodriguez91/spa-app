using AccesoDatos.Interfaces;
using Dominio.Entities;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IConfiguration configuration;
        private readonly IApiService apiService;

        public EmployeeService(IConfiguration configuration, IApiService apiService)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        public async Task<RestResponse<ApiResponse<List<Employee>>>> GetAllAsync()
        {
            var employees = await this.apiService.SendRequestAsync<ApiResponse<List<Employee>>>($"{configuration["apiEmployees"]!}/employees");
            return employees;
        }

        public async Task<RestResponse<ApiResponse<Employee?>>> GetByIdAsync(int id)
        {
            var employee = await this.apiService.SendRequestAsync<ApiResponse<Employee?>>($"{configuration["apiEmployees"]!}/employee/{id}");
            return employee;
        }
    }
}
