using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;



namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public void CreateCompany(Company company) => Create(company);

        public void DeleteCompanies(Company company, bool trackChanges) => Delete(company);

        public async Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges)
        {
            var x = await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
            return x;
        }

        public async Task<IEnumerable<Company>> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            var x = await FindByCondition(c => ids.Contains(c.Id), trackChanges)
                 .OrderBy(c => c.Name)
                 .ToListAsync();
            return x;
        }

        public async Task<Company> GetCompany(Guid companyId, bool trackChanges)
        {
            var x = await FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefaultAsync();
            if (x == null)
                throw new CompanyNotFoundException(companyId);
            return x;
        }

    }
}