using Contracts;
using Entities.Models;
using Service.Contracts;

namespace Service
{
    public sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        IEnumerable<Company> ICompanyService.GetAllCompanies(bool trackChanges)
        {
            var x = _repositoryManager.Company.GetAllCompanies;
            try 
            {
                var companies = x(trackChanges); 
                return companies; 
            } 
            catch (Exception ex) 
            { 
                _loggerManager.LogError($"Something went wrong in the {nameof(x)} service method {ex}"); 
                throw;
            }
        }
    }
}
