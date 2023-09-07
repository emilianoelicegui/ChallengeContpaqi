using Microsoft.AspNetCore.Mvc;

namespace Contpaqi.Web.Controllers
{
    public class EmployeeController : _GenericController<EmployeeController>
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
