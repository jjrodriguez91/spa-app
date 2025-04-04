using AccesoDatos.Interfaces;
using Dominio.Dto;
using Negocio.Employees.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Employees
{
    public class Employee : IEmployee
    {
        private readonly IEmployeeService employeeService;

        public Employee(IEmployeeService employeeService)
        {
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        public async Task<List<EmployeeDto>?> GetAllAsync()
        {
            var employeesResponse = await employeeService.GetAllAsync();
            List<EmployeeDto> employees = new List<EmployeeDto>();
            if(employeesResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<Dominio.Entities.Employee>? employeesList = employeesResponse.Data!.Data!;
                employees = employeesList.Select(e => new EmployeeDto
                {
                    Age = e.Employee_age,
                    AnnualSalary = GetEmployeeAnnualSalary(e.Employee_salary),
                    Id = e.Id,
                    Name = e.Employee_name,
                    Profile_image = e.Profile_image,
                    Salary = e.Employee_salary
                }).ToList();
            }
            else
            {
                throw new Exception($"{employeesResponse.StatusCode} - {employeesResponse.ErrorMessage}");
            }
            return employees;
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var restResponse = await employeeService.GetByIdAsync(id);
            EmployeeDto? employeeDto = null;
            if(restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                employeeDto = new EmployeeDto
                {
                    Age = restResponse.Data!.Data!.Employee_age,
                    AnnualSalary = GetEmployeeAnnualSalary(restResponse.Data.Data.Employee_salary),
                    Id = restResponse.Data.Data.Id,
                    Name = restResponse.Data.Data.Employee_name,
                    Profile_image = restResponse.Data.Data.Profile_image,
                    Salary = restResponse.Data.Data.Employee_salary
                };
            }else if(restResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception($"{restResponse.StatusCode} - {restResponse.ErrorMessage}");
            }
            return employeeDto;
        }

        public decimal GetEmployeeAnnualSalary(decimal salary)
        {
            return salary * 12;
        }
    }
}
