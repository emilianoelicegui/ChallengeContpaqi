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
            return Ok(await _employeeService.GetAsync(id));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeService.GetAllAsync());
        }

        [HttpPut("AddOrUpdate")]
        public async Task<IActionResult> AddOrUpdate([FromBody] EmployeeDto employeeDto)
        {
            await _employeeService.AddOrUpdateAsync(employeeDto);
            return Ok();
        }
    }
}
