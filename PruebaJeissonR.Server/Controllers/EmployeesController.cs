using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Negocio.Employees.Interfaces;

namespace PruebaJeissonR.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private IEmployee _employee;

        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployee employee)
        {
            _logger = logger;
            _employee = employee;
        }

        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _employee.GetAllAsync();
                return Ok(response);

            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                throw;
            }
        }

        [HttpGet("GetEmployee")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            try
            {
                var response = await _employee.GetByIdAsync(id);
                if (response == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                throw;
            }
        }
    }
}
