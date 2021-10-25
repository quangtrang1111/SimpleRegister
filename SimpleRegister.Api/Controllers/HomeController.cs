using Microsoft.AspNetCore.Mvc;

namespace SimpleRegister.Api.Controllers
{
    [ApiController]
    public class Controller : ControllerBase
    {
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            return Redirect("index.html");
        }
    }
}
