using AutoMapper;
using Contpaqi.Data.DataTransferObjects;
using Contpaqi.Data.Models;


namespace Contpaqi.Data.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeListDto>()
                .ForMember(dist => dist.FullName, opt => opt
                .MapFrom(src => $"{src.Name}, {src.LastName} {src.MiddleName}"));

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
        }
    }

}
