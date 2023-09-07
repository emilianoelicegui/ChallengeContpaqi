using Contpaqi.Data.Contexts;
using Contpaqi.Data.Models;
using Contpaqi.Data.Repositories.Impl;

namespace Contpaqi.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ContpaqiDbContext context) : base(context)
        { }
    }

}
