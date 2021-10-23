using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRegister.Controllers
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
