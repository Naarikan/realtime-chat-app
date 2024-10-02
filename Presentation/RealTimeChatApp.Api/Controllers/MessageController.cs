using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealTimeChatApp.Application.Features.Messages.Command.CreateMessage;
using RealTimeChatApp.Application.Features.Messages.Queries.GetGroupMessages;
using RealTimeChatApp.Application.Features.UserGroupRoles.Queries.GetAllGroupsWithLastMessage;
using RealTimeChatApp.Application.Features.UserGroupRoles.Queries.GetMessagesByGroup;

using RealTimeChatApp.Infrastructure.SignalR;

namespace RealTimeChatApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MessageController : ControllerBase
    {
        IMediator mediator;
       

        public MessageController(IMediator mediator)
        {
            this.mediator = mediator;
           
        }

        [Authorize]
        [HttpGet("getallmessages")]
        public async Task<IActionResult> GetAllMessages()
        {
            var response = await mediator.Send(new GetAllMessagesQueryRequest());
            return Ok(response);
        }

        [HttpGet("group/{groupChatId}")]
        public async Task<IActionResult> GetMessagesByGroup(Guid groupChatId)
        {
            var query = new GetMessagesByGroupQueryRequest { GroupChatId = groupChatId };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("grouproleuser/{userId}")]
        public async Task<IActionResult> GetGroupRoleUser(Guid userId)
        {
            var query = new GetAllGroupsWithLastMessageQueryRequest { UserId = userId };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpPost("create-message")]
        public async Task<IActionResult> CreateMessage(CreateMessageCommandRequest request)
        {
            await mediator.Send(request);
           
            return Ok();

        }
    }
}
