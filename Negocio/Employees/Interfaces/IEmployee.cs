
using Dominio.Dto;

namespace Negocio.Employees.Interfaces
{
    public interface IEmployee
    {
        /// <summary>
        /// Obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        Task<List<EmployeeDto>?> GetAllAsync();

        /// <summary>
        /// obtiene un empleado por id
        /// </summary>
        /// <param name="id">id empleado</param>
        /// <returns>empleado si hay si no null</returns>
        Task<EmployeeDto?> GetByIdAsync(int id);

        /// <summary>
        /// obtiene el saluario anual de un emp
        /// </summary>
        /// <param name="salary">salario mensual</param>
        /// <returns>salario anual</returns>
        decimal GetEmployeeAnnualSalary(decimal salary);
    }
}
