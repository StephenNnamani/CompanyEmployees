using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEmployeesService
    {
        public Task<IEnumerable<EmployeeDto>> GetAllEmployees(bool trackChanges);
        
        public Task<IEnumerable<EmployeeDto>> GetAllCompanyEmployees(Guid companyId, bool trackChanges);
        public Task<EmployeeDto> GetEmployee(Guid Id, bool trackChanges);

        public string CreateEmployee(CreateEmployeeDto createEmployee);

    }
}
