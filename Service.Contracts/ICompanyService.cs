using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        public Task<IEnumerable<CompanyDto>> GetAllCompanies(bool trackChanges);
        public Task<CompanyDto> GetCompany(Guid companyId, bool trackChanges);
        public CompanyDto CreateCompany(CreateCompanyDto createCompany);
    }
}
