using AutoMapper;
using Contracts;
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
        IEnumerable<EmployeeDto> IEmployeesService.GetAllEmployees(bool trackChanges)
        {

            var employees = _repositoryManager.Employee.GetAllEmployees(trackChanges);
            var employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return employeeDto;

        }

    }
}
