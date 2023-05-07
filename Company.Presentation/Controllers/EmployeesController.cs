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
    [Route("api/companies/{employeeId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EmployeesController(IServiceManager service) =>
            _service = service;

        [Route("Getallemployees")]
        [HttpGet (Name = "Get all employees")]
        public async Task<IActionResult> GetAllEmployees(Guid companyId)
        {
            var employees = await _service.EmployeesService.GetAllEmployees(companyId, trackChanges: false);
            return Ok(employees);
        }
        [Route("EmployeeProfile")]
        [HttpGet (Name = "Get an employee")]
        public async Task<IActionResult> GetEmployee(Guid Id, Guid companyId)
        {
            var employee = await _service.EmployeesService.GetEmployee(Id, companyId, trackChanges: false);
            return Ok(employee);
        }

        [Route("CreateEmployee")]
        [HttpPost (Name = "Create new employees")]
        public IActionResult CreateEmployee([FromBody] CreateEmployeeDto createEmployee)
        {
            if (createEmployee == null) 
                return BadRequest("CreateEmployeeDto Object is null");
            var createdEmployee = _service.EmployeesService.CreateEmployee(createEmployee);

            return CreatedAtRoute("EmployeeId", new { id = createdEmployee.Id }, createdEmployee);
        }
    }
}
