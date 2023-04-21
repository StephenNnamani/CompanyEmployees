using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

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

        IEnumerable<CompanyDto> ICompanyService.GetAllCompanies(bool trackChanges)
        {
            try
            {
                var companies = _repositoryManager.Company.GetAllCompanies(trackChanges);
                var companiesDto = companies.Select(x => new CompanyDto(x.Id, x.Name ?? " ", string.Join(" ", x.Address, x.Country))).ToList();
                return companiesDto;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(ICompanyService.GetAllCompanies)} service method {ex}");
                throw;
            }
        }
    }
}

