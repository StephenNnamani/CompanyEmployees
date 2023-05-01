using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EmployeesController(IServiceManager service) =>
            _service = service;

        [Route("Company_Employees")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(Guid companyId)
        {
            var employees = await _service.EmployeesService.GetAllEmployees(companyId, trackChanges: false);
            return Ok(employees);
        }
        [Route("Employee_Profile")]
        [HttpGet]
        public async Task<IActionResult> GetEmployee(Guid Id, Guid companyId)
        {
            var employee = await _service.EmployeesService.GetEmployee(Id, companyId, trackChanges: false);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] CreateEmployeeDto createEmployee)
        {
            if (createEmployee == null) 
                return BadRequest("CreateEmployeeDto Object is null");
            var createdEmployee = _service.EmployeesService.CreateEmployee(createEmployee);

            return CreatedAtRoute("EmployeeById", new { id = createdEmployee.Id }, createdEmployee);
        }
    }
}
