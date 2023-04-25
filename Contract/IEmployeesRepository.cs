using Entities.Models;

namespace Contracts
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees(Guid companyId, bool trackChanges);
        Task<Employee> GetEmployee(Guid Id, Guid companyId, bool trackChanges);
    }
}
