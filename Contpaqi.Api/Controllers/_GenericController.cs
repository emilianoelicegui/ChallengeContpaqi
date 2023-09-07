using Microsoft.AspNetCore.Mvc;

namespace Contpaqi.Api.Controllers
{
    [ApiController]
    public abstract class _GenericController<T> : ControllerBase where T : _GenericController<T>
    {
        private ILogger<T> logger;

        protected ILogger<T> _logger => logger ?? (logger = HttpContext.RequestServices.GetService<ILogger<T>>());

    }
}
