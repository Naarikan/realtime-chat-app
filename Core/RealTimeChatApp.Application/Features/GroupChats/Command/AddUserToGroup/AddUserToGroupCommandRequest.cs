using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RealTimeChatApp.Application.Features.GroupChats.Command.AddUserToGroup
{
    public class AddUserToGroupCommandRequest:IRequest<Unit>
    {
        public string Email { get; set; }

        public Guid GroupChatId { get; set; }
    }
}
