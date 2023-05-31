using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetAllCompanies(bool trackChanges);
        public Task<Company> GetCompany(Guid Id, bool trackChanges);
        public Task<IEnumerable<Company>> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        public void CreateCompany(Company company);
        public void DeleteCompanies(IEnumerable<Guid> companiesIds, bool trackChanges);
    }
}
