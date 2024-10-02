using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealTimeChatApp.Application.Features.GroupChats.Command.GetMembersInGroup;
using RealTimeChatApp.Application.Features.Roles.Command.ChangeUserRole;
using RealTimeChatApp.Application.Features.Roles.Queries.GetUserRoleInGroup;
using RealTimeChatApp.Application.Features.UserGroupRoles.Command.AddUserToGroupWithRole;
using RealTimeChatApp.Application.Features.UserGroupRoles.Command.RemoveUserFromGroup;

namespace RealTimeChatApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupRoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserGroupRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-user-to-group")]
        public async Task<IActionResult> AddUserToGroup(AddUserToGroupWithRoleCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("get-members/{groupChatId}")]
        public async Task<IActionResult> GetMembers(Guid groupChatId)
        {
            var query = new GetMembersInGroupCommandRequest { GroupId = groupChatId };

            var response = await _mediator.Send(query);
            return Ok(response);
        }


        [HttpGet("get-user-role/{userId}/{groupId}")]

        public async Task<IActionResult> GetUserRole(Guid userId, Guid groupId)
        {
            var query = new GetUserRoleInGroupQueryRequest { UserId = userId, GroupId = groupId };
            var response = await _mediator.Send(query);
            return Ok(response);
        }


        [HttpPost("change-user-role")]
        public async Task<IActionResult> ChangeUserRole(ChangeUserRoleCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }


        [HttpPost("remove-user-from-group")]
        public async Task<IActionResult> RemoveUser(RemoveUserFromGroupCommandRequest request) { 
        
            await _mediator.Send(request);
            return Ok();
        
        }

	}
}
