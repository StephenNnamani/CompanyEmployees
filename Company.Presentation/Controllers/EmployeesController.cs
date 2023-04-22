using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EmployeesController(IServiceManager service) =>
            _service = service;

        [Route("/ListOfEmployees")]
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _service.EmployeesService.GetAllEmployees(trackChanges: false);
            return Ok(employees);
        }
    }
}
