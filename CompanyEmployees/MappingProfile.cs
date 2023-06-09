﻿using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace CompanyEmployees
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember("FullAddress", opt => opt.MapFrom(x => string.Join(", ", x.Address, x.Country)));

            CreateMap<Employee, EmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<CreateCompanyDto, Company>();
            CreateMap<CreateEmployeeDTOwithoutId, Employee>();
        }
    }
}
