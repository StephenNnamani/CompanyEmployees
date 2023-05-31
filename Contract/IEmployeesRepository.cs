using Entities.Models;

namespace Contracts
{
    public interface IEmployeesRepository
    {
        public Task<IEnumerable<Employee>> GetAllEmployees(bool trackChanges);
        public Task<IEnumerable<Employee>> GetAllCompanyEmployees(Guid companyId, bool trackChanges);
        public Task<Employee> GetEmployee(Guid Id, bool trackChanges);
        public Task<IEnumerable<Employee>> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        public void CreateEmployee(Employee employee);
        public void DeleteEmployies(IEnumerable<Guid> employeeIds, bool trackChanges);
    }
}
