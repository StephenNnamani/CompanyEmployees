using Entities.Models;

namespace Contracts
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees(bool trackChanges);
        Task<Employee> GetEmployee(Guid Id, bool trackChanges);
    }
}
