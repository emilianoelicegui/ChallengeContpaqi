using AutoMapper;
using Contpaqi.Data.DataTransferObjects;
using Contpaqi.Data.Models;
using Contpaqi.Data.UnitOfWork;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Security;

namespace Contpaqi.Application.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<EmployeeService> logger) 
        { 
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddOrUpdateAsync(EmployeeDto employeeDto)
        {
            try
            {
                _logger.LogInformation("AddOrUpdateAsync service init ..");

                Expression<Func<Employee, bool>> f = c => true;
                var employee = employeeDto.Id != null ? _unitOfWork.EmployeeRepository
                    .Get(expression: f = f.And(x => x.Id == employeeDto.Id)) : null;

                if (employee == null)
                    _unitOfWork.EmployeeRepository
                        .Add(_mapper.Map<Employee>(employee));
                else  
                    _mapper.Map<Employee>(employee);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error AddOrUpdateAsync: {ex.Message}");
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeListDto>> GetAllAsync()
        {
            _logger.LogInformation("GetAllAsync service init ..");

            return _mapper.Map<IEnumerable<EmployeeListDto>>
                (await _unitOfWork.EmployeeRepository.GetAllAsync());
        }

        public async Task<EmployeeDto> GetAsync(int id)
        {
            _logger.LogInformation("GetAsync service init ..");

            Expression<Func<Employee, bool>> f = c => true;

            var employeeDto = _mapper.Map<EmployeeDto>
                (await _unitOfWork.EmployeeRepository
                .GetAsync(expression: f = f.And(x => x.Id == id)));

            if (employeeDto == null)
                throw new ValidationException("El empleado no existe");

            return _mapper.Map<EmployeeDto>
                (employeeDto);
        }
    }
}
