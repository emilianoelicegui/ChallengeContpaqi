using Contpaqi.Application.Services;
using Contpaqi.Data.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Contpaqi.Api.Controllers
{
    //[TypeFilter(typeof(CinemaFilter))]
    [Route("api/[controller]")]
    public class EmployeeController : _GenericController<EmployeeController>
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _employeeService.GetAsync(id));
            }
            catch
            {
                return BadRequest("Error al buscar el empleado");
            }
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromBody] EmployeeFilterListDto employeeFilterList)
        {
            try
            {
                return Ok(await _employeeService.GetAllAsync(employeeFilterList));
            }
            catch
            {
                return BadRequest("Error al filtrar empleados");
            }
        }

        [HttpPut("AddOrUpdate")]
        public async Task<IActionResult> AddOrUpdate([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                await _employeeService.AddOrUpdateAsync(employeeDto);
                return Ok();
            }
            catch
            {
                return BadRequest("Error al actualizar el empleado");
            }
        }
    }
}
