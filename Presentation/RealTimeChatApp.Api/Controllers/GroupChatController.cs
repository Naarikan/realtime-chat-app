using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealTimeChatApp.Application.Features.GroupChats.Command.AddUserToGroup;
using RealTimeChatApp.Application.Features.GroupChats.Command.CreateInviteCode;
using RealTimeChatApp.Application.Features.GroupChats.Command.CreateNewGroup;
using RealTimeChatApp.Application.Features.GroupChats.Command.UseInviteCode;

namespace RealTimeChatApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupChatController : ControllerBase
    {
        private readonly IMediator mediator;

        public GroupChatController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create-groupchat")]
        public async Task<IActionResult> CreateGroup(CreateNewGroupCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost("create-invite-code")]
        public async Task<IActionResult> CreateInviteCode([FromBody] CreateInviteCodeCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }


        [HttpPost("add-user-to-group")]
        public async Task<IActionResult> UseInviteCode([FromBody] UseInviteCodeCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost("add-one-user-to-group")]
        public async Task<IActionResult> AddOneUserToGroup([FromBody] AddUserToGroupCommandRequest request) 
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
