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

        [Route("/ListOfCompanies")]
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _service.CompanyService.GetAllCompanies(trackChanges: false);
            return Ok(companies);
        }

        [Route("CompanyProfile/")]
        [HttpGet]
        public async Task<IActionResult> GetCompany(Guid Id)
        {
            var company = await _service.CompanyService.GetCompany(Id, trackChanges: false);
            return Ok(company);
        }
    }
}
