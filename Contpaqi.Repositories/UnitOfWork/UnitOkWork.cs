using Contpaqi.Data.Contexts;
using Contpaqi.Data.Repositories;
using Contpaqi.Data.Repositories.Impl;

namespace Contpaqi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContpaqiDbContext _dbContext;
        private IEmployeeRepository _employeeRepository;

        public UnitOfWork(ContpaqiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEmployeeRepository EmployeeRepository
        {
            get { return _employeeRepository = _employeeRepository ?? new EmployeeRepository(_dbContext); }
        }

        public void Commit()
            => _dbContext.SaveChanges();

        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();

        public void Rollback()
            => _dbContext.Dispose();

        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
