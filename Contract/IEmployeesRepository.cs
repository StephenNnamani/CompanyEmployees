using Entities.Models;

namespace Contracts
{
    public interface IEmployeesRepository
    {
        public Task<IEnumerable<Employee>> GetAllEmployees(bool trackChanges);
        public Task<IEnumerable<Employee>> GetAllCompanyEmployees(Guid companyId, bool trackChanges);
        public Task<Employee> GetEmployee(Guid Id, bool trackChanges);
        public void CreateEmployee(Employee employee);
    }
}
