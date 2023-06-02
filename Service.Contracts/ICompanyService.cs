using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        public Task<IEnumerable<CompanyDto>> GetAllCompanies(bool trackChanges);
        public Task<CompanyDto> GetCompany(Guid companyId, bool trackChanges);
        public Task<IEnumerable<CompanyDto>> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        public string CreateCompany(CreateCompanyDto createCompany);
        public (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection(IEnumerable<CreateCompanyDto> companyCollection);
        public Task DeleteCompanies(IEnumerable<Guid> companyId, bool trackChanges);
    }
}
