using AccesoDatos.Impl;
using AccesoDatos.Interfaces;
using Dominio.Entities;
using Moq;
using RestSharp;
using System.Text.Json;
using Negocio;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Dominio.Dto;

namespace Test
{
    public class Tests
    {
        private Mock<IEmployeeService> mockEmployeeService;
        private Negocio.Employees.Employee mockEmployee;

        [SetUp]
        public void Setup()
        {
            mockEmployeeService = new Mock<IEmployeeService>();
            mockEmployee = new Negocio.Employees.Employee(mockEmployeeService.Object);
        }

        [Test]
        public async Task GetByIdAndValidateAnnualSalaryTest()
        {
            // Arrange
            int employeeId = 1;
            var expectedEmployee = new Employee { Id = employeeId, Employee_name = "pepito", Employee_salary=100 };
            decimal expectedAnnualSalary = 100 * 12;
            var apiResponse = new ApiResponse<Employee?> { Data = expectedEmployee, Status="success" };

            var restResponse = new RestResponse<ApiResponse<Employee?>>(new RestRequest())
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Data = apiResponse
            };


            mockEmployeeService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(restResponse);
            // Act
            EmployeeDto? response = await mockEmployee.GetByIdAsync(employeeId);

            // Assert
            Assert.IsNotNull(response);//valida que cree el objeto del empleado
            Assert.That(response.AnnualSalary, Is.EqualTo(expectedAnnualSalary));//valida la regla de negocio del salario anual
        }

    }
}