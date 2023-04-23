using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace CompanyEmployees
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForCtorParam("FullAddress", opt => opt.MapFrom(x => string.Join(", ", x.Address, x.Country)));
            CreateMap<Employee, EmployeeDto>()
                .ForMember(c => c.Name, opt => opt.MapFrom(c => c.Name))
                .ForMember(c => c.age, opt => opt.MapFrom(c => c.Age))
                .ForMember(c => c.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(c => c.Position, opt => opt.MapFrom(c => c.Position));
        }
    }
}
