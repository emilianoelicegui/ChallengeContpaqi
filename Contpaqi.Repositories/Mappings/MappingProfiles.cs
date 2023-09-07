using AutoMapper;
using Contpaqi.Data.DataTransferObjects;
using Contpaqi.Data.Models;


namespace Contpaqi.Data.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeListDto>();

            CreateMap<EmployeeDto, Employee>();
        }
    }

}
