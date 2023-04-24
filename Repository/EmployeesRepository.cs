using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Employee> GetEmployee(Guid EmployeeId, bool trackChanges)
        {
            var x = await FindByCondition(c => c.Id.Equals(EmployeeId), trackChanges).SingleOrDefaultAsync();
            if (x == null)
                throw new CompanyNotFoundException(EmployeeId);
            return x;
        }
    }
}
