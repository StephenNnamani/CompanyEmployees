using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
            : base (repositoryContext)
        {

        }
        IEnumerable<Company> ICompanyRepository.GetAllCompanies(bool trackChanges) => 
            FindAll(trackChanges)
            .OrderBy(x => x.Name)
            .ToList();
        Company ICompanyRepository.GetCompany(Guid Id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(Id), trackChanges)
            .SingleOrDefault();
    }
}
