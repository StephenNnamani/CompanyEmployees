﻿using CompanyEmployees.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/companies/employees")]
    //[ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EmployeesController(IServiceManager service) =>
            _service = service;

        [Route("Getallemployees")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _service.EmployeesService.GetAllEmployees(trackChanges: false);
            return Ok(employees);
        }


        [Route("GetallCompanyEmployees")]
        [HttpGet]
        public async Task<IActionResult> GetAllCompanyEmployees(Guid companyId)
        {
            var employees = await _service.EmployeesService.GetAllCompanyEmployees(companyId, trackChanges: false);
            return Ok(employees);
        }

        [Route("EmployeeProfile")]
        [HttpGet]
        public async Task<IActionResult> GetEmployee(Guid Id)
        {
            var employee = await _service.EmployeesService.GetEmployee(Id, trackChanges: false);
            return Ok(employee);
        }


        [HttpGet("GetEmployeesByIds")]
        public async Task<IActionResult> GetEmployeeByIds([ModelBinder(typeof(ArrayModelBinder))] IEnumerable<Guid> Ids)
        {
              var employee = await _service.EmployeesService.GetByIds(Ids, trackChanges: false);
             
            return Ok(employee);
        }

        [HttpPost("create-employee", Name = "Create-new-employees")]
        public IActionResult CreateEmployee([FromBody] IEnumerable<CreateEmployeeDto> createEmployee)
        {
            if (createEmployee == null)
                return BadRequest("CreateEmployeeDto Object is null");
            var createdEmployee = _service.EmployeesService.CreateEmployee(createEmployee);

            return Ok(createdEmployee);

        }

        [HttpDelete("delete-employee", Name = "delete-employee")]
        public IActionResult DeleteEmployees(IEnumerable<Guid> employeesId)
        {
            _service.EmployeesService.DeleteEmployee(employeesId, trackChanges: false);

            return NoContent();
        }

    }
}
