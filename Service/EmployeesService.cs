using AutoMapper;
using Contracts;
using Entities.Exceptions;
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

        public async Task<EmployeeDto> GetEmployee(Guid Id, bool trackChanges)
        {
            var employee = await _repositoryManager.Employee.GetEmployee(Id, trackChanges);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees(bool trackChanges)
        {

            var employeesFromDb = await _repositoryManager.Employee.GetAllEmployees(trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
            return employeesDto;

        }

        public async Task<IEnumerable<EmployeeDto>> GetAllCompanyEmployees(Guid companyId, bool trackChanges)
        {

            var employeesFromDb = await _repositoryManager.Employee.GetAllCompanyEmployees(companyId, trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
            return employeesDto;

        }

        public string CreateEmployee(IEnumerable<CreateEmployeeDto> createEmployee)
        {
            var employeeEntity = _mapper.Map<IEnumerable<Employee>>(createEmployee);

            foreach( var employee in employeeEntity)
            {
                _repositoryManager.Employee.CreateEmployee(employee);
            }
            _repositoryManager.Save();
            return "Employee Successfully created";
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids == null)
                throw new IdParametersBadRequestException();

            var employees = await _repositoryManager.Company.GetByIds(ids, trackChanges);

            if (ids.Count() != employees.Count())
                throw new CollectionByIdsBadRequestException();

            var employeeDtoCollection = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return employeeDtoCollection;
        }
    }
}
