using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RealTimeChatApp.Application.Features.UserGroupRoles.Command.RemoveUserFromGroup
{
    public class RemoveUserFromGroupCommandRequest:IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
    }
}
