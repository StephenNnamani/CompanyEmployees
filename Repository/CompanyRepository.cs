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
        async Task<IEnumerable<Company>> ICompanyRepository.GetAllCompanies(bool trackChanges)
        {
            var x = await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
            return x;
        }
        async Task<Company> ICompanyRepository.GetCompany(Guid companyId, bool trackChanges)
        {
            var x = await FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefaultAsync();
            if (x == null)
                throw new CompanyNotFoundException(companyId);
            return x;
        }

    }
}