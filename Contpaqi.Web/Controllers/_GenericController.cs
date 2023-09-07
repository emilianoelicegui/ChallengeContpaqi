using Microsoft.AspNetCore.Mvc;

namespace Contpaqi.Web.Controllers
{
    public abstract class _GenericController<T> : Controller where T : _GenericController<T>
    {
        private ILogger<T> logger;
        protected ILogger<T> _logger => logger ?? (logger = HttpContext.RequestServices.GetService<ILogger<T>>());
    }
}
