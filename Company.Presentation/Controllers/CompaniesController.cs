using CompanyEmployees.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("Companies")]
    //[ApiController]
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

        [Route("/Comanies-search/")]
        [HttpGet]
        public async Task<IActionResult> GetCompaniesById([ModelBinder(typeof(ArrayModelBinder))] IEnumerable<Guid> Ids)
        {
            var company = await _service.CompanyService.GetByIds(Ids, trackChanges: false);
            return Ok(company);
        }


        [HttpPost ("create-company", Name = "create-company")]
        public IActionResult CreateCompany([FromBody] CreateCompanyDto company)
        {
            if (company == null)
                return BadRequest("CreateCompanyDto object is null");

            var createdCompany = _service.CompanyService.CreateCompany(company);

            return Ok(createdCompany);
        }

        [HttpPost("Create-company-collection", Name = "Create-company-collection")]
        public IActionResult CreateCompanyCollection([FromBody] IEnumerable<CreateCompanyDto> companyCollection)
        {
            if (companyCollection == null)
                return BadRequest("CreateCompanyDto object is null");

            var createdCompany = _service.CompanyService.CreateCompanyCollection(companyCollection);

            return Ok(createdCompany);
        }

        [HttpDelete("delete-companies", Name = "delete-company")]
        public IActionResult DeleteCompanies(IEnumerable<Guid> companyIds)
        {
            _service.CompanyService.DeleteCompanies(companyIds, trackChanges: false);

            return NoContent();
        }
    }
}
