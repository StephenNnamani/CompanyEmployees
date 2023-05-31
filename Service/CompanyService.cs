using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public async Task<CompanyDto> GetCompany(Guid companyId, bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompany(companyId, trackChanges);
            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompanies(bool trackChanges)
        {
            var companies = await _repositoryManager.Company.GetAllCompanies(trackChanges);
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companiesDto;
        }

        public string CreateCompany(CreateCompanyDto createCompany)
        {
            var companyEntity = _mapper.Map<Company>(createCompany);
            _repositoryManager.Company.CreateCompany(companyEntity);
            _repositoryManager.Save();

            var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);
            return "Company successfully created";
        }

        public async Task<IEnumerable<CompanyDto>> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids == null)
                throw new IdParametersBadRequestException();

            var companies = await _repositoryManager.Company.GetByIds(ids, trackChanges);

            if(ids.Count() != companies.Count())
                throw new CollectionByIdsBadRequestException();

            var companiesDtoCollection = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companiesDtoCollection;
        }

        public (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection(IEnumerable<CreateCompanyDto> companyCollection) 
        { 
            if (companyCollection is null) 
                throw new CollectionByIdsBadRequestException(); 
            
            var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection); 
            foreach (var company in companyEntities) 
            { 
                _repositoryManager.Company.CreateCompany(company); 
            } 
            _repositoryManager.Save(); 
            
            var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities); 
            var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id)); 
            return (companies: companyCollectionToReturn, ids: ids); 
        }

        public void DeleteCompany(IEnumerable<Guid> companyId)
        {
            throw new NotImplementedException();
        }
    }
}

