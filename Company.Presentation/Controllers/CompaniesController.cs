﻿using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/Companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CompaniesController(IServiceManager service) =>
            _service = service;

        [Route("ListOfCompanies")]
        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _service.CompanyService.GetAllCompanies(trackChanges: false);
            return Ok(companies);
        }

        [Route("CompanyProfile")]
        [HttpGet]
        public IActionResult GetEmployee(Guid Id)
        {
            var company = _service.CompanyService.GetCompany(Id, trackChanges: false);
            return Ok(company);
        }
    }
}
