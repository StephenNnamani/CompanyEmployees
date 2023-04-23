using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEmployeesService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges);
        EmployeeDto GetEmployee(Guid Id, bool trackChanges);

    }
}
