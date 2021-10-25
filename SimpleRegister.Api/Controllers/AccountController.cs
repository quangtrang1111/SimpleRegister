using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleRegister.Application.Commands;
using SimpleRegister.Application.Models;
using SimpleRegister.Application.Queries;
using System.Threading.Tasks;

namespace SimpleRegister.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> SignUp(RegisterAccountCommand command)
        {
            command.HostUrl = $"{Request.Scheme}://{Request.Host}{Url.Action(nameof(ConfirmEmail))}";

            await Mediator.Send(command, HttpContext.RequestAborted);

            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail([FromQuery] ConfirmAccountEmailCommand command)
        {
            await Mediator.Send(command, HttpContext.RequestAborted);

            return Redirect($"{Request.Scheme}://{Request.Host}");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<UserModel>> GetProfile()
        {
            var query = new GetAccountProfileQuery { Username = HttpContext.User.Identity.Name };

            return await Mediator.Send(query, HttpContext.RequestAborted);
        }
    }
}
