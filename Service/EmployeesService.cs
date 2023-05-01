using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public sealed class EmployeesService : IEmployeesService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public EmployeesService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> GetEmployee(Guid Id, Guid companyId, bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompany(companyId, trackChanges);
            var employee = await _repositoryManager.Employee.GetEmployee(Id, companyId, trackChanges);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees(Guid companyId, bool trackChanges)
        {

            var employeesFromDb = await _repositoryManager.Employee.GetAllEmployees(companyId, trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
            return employeesDto;

        }

        public EmployeeDto CreateEmployee(CreateEmployeeDto createEmployee)
        {
            var employeeEntity = _mapper.Map<Employee>(createEmployee);
            _repositoryManager.Employee.CreateEmployee(employeeEntity);
            _repositoryManager.Save();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);
            return employeeToReturn;
        }
    }
}
