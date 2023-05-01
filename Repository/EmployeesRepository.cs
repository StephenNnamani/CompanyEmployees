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

        async Task<IEnumerable<Employee>> IEmployeesRepository.GetAllEmployees(Guid Id, bool trackChanges)
        {
            var x = await FindByCondition(c => c.CompanyId.Equals(Id), trackChanges).OrderBy(c => c.Name).ToListAsync();
            return x;
        }

        public async Task<Employee> GetEmployee(Guid EmployeeId, Guid companyId, bool trackChanges)
        {
            var x = await FindByCondition(c => c.Id.Equals(EmployeeId) && c.Id.Equals(companyId), trackChanges).SingleOrDefaultAsync();
            if (x == null)
                throw new CompanyNotFoundException(EmployeeId);
            return x;
        }

        public void CreateEmployee(Employee employee) => Create(employee);
    }
}
