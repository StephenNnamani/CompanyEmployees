using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EmployeesRepository : RepositoryBase<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        async Task<IEnumerable<Employee>> IEmployeesRepository.GetAllEmployees(bool trackChanges)
        {
            var x = await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
            return x;
        }

        async Task<IEnumerable<Employee>> IEmployeesRepository.GetAllCompanyEmployees(Guid CompanyId, bool trackChanges)
        {
            var x = await FindByCondition(c => c.CompanyId.Equals(CompanyId), trackChanges).OrderBy(c => c.Name).ToListAsync();
            return x;
        }
        public async Task<Employee> GetEmployee(Guid EmployeeId, bool trackChanges)
        {
            var x = await FindByCondition(c => c.Id.Equals(EmployeeId), trackChanges).SingleOrDefaultAsync();
            if (x == null)
                throw new CompanyNotFoundException(EmployeeId);
            return x;
        }

        public void CreateEmployee(Employee employee) => Create(employee);
    }
}
