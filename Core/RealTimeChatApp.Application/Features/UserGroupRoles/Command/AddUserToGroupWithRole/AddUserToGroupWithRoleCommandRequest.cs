using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RealTimeChatApp.Application.Features.UserGroupRoles.Command.AddUserToGroupWithRole
{
    public class AddUserToGroupWithRoleCommandRequest:IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid GroupChatId { get; set; }
    }
}
