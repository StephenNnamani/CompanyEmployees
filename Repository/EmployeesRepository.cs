using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
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

        IEnumerable<Employee> IEmployeesRepository.GetAllEmployees(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(x => x.Name)
            .ToList();
    }
}
