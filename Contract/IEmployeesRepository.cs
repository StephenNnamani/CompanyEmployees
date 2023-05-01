using Entities.Models;

namespace Contracts
{
    public interface IEmployeesRepository
    {
        public Task<IEnumerable<Employee>> GetAllEmployees(Guid companyId, bool trackChanges);
        public Task<Employee> GetEmployee(Guid Id, Guid companyId, bool trackChanges);
        public void CreateEmployee(Employee employee);
    }
}
