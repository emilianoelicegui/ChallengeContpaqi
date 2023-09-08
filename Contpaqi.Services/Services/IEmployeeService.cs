using Contpaqi.Data.DataTransferObjects;

namespace Contpaqi.Application.Services
{
    public interface IEmployeeService
    {
        Task AddOrUpdateAsync(EmployeeDto employee);
        Task<ObjectListDto<EmployeeListDto>> GetAllAsync(EmployeeFilterListDto filterList);
        Task<EmployeeDto> GetAsync(int id);
    }
}
