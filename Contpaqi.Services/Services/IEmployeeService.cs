using Contpaqi.Data.DataTransferObjects;

namespace Contpaqi.Application.Services
{
    public interface IEmployeeService
    {
        Task AddOrUpdateAsync(EmployeeDto employee);
        Task<IEnumerable<EmployeeListDto>> GetAllAsync();
        Task<EmployeeDto> GetAsync(int id);
    }
}
