﻿using Contracts;
using Service.Contracts;

namespace Service
{
    internal sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeesService> _employeesService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, loggerManager));
            _employeesService = new Lazy<IEmployeesService>(() => new EmployeesService(repositoryManager, loggerManager));
        }
    }
}