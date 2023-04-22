using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeesService> _employeesService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, loggerManager, mapper));
            _employeesService = new Lazy<IEmployeesService>(() => new EmployeesService(repositoryManager, loggerManager, mapper));
        }

        ICompanyService IServiceManager.CompanyService => _companyService.Value;

        IEmployeesService IServiceManager.EmployeesService => _employeesService.Value;

    }
}
