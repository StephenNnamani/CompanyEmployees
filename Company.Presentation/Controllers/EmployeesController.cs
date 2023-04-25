using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EmployeesController(IServiceManager service) =>
            _service = service;

        [Route("/ListOfEmployees")]
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _service.EmployeesService.GetAllEmployees(trackChanges: false);
            return Ok(employees);
        }

        [Route("EmployeeProfile/")]
        [HttpGet]
        public async Task<IActionResult> GetEmployee(Guid Id)
        {
            var employee = await _service.EmployeesService.GetEmployee(Id, trackChanges: false);
            return Ok(employee);
        }
    }
}
