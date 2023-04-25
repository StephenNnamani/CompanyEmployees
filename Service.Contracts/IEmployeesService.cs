using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEmployeesService
    {
        public Task<IEnumerable<EmployeeDto>> GetAllEmployees(Guid companyId, bool trackChanges); 
        public Task<EmployeeDto> GetEmployee(Guid Id, Guid companyId, bool trackChanges);

    }
}
