using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using RealTimeChatApp.Application.Features.Auth.Command.Login;
using RealTimeChatApp.Application.Features.Auth.Command.Register;

namespace RealTimeChatApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);

        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response= await mediator.Send(request);
            return Ok(response);
        }


    }
}
