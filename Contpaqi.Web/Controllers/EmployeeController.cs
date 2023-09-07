using Contpaqi.Data.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Contpaqi.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<EmployeeListDto>());
        }

        public IActionResult AddOrUpdate()
        {
            return View();
        }
    }
}
