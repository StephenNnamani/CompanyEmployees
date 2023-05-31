using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEmployeesService
    {
        public Task<IEnumerable<EmployeeDto>> GetAllEmployees(bool trackChanges);
        
        public Task<IEnumerable<EmployeeDto>> GetAllCompanyEmployees(Guid companyId, bool trackChanges);
        public Task<EmployeeDto> GetEmployee(Guid Id, bool trackChanges);
        public Task<IEnumerable<EmployeeDto>> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        public string CreateEmployee(IEnumerable<CreateEmployeeDto> createEmployee);
        public void DeleteEmployee(IEnumerable<Guid> employeeIds);

    }
}
