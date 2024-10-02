using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RealTimeChatApp.Application.Features.Messages.Command.CreateMessage
{
    public class CreateMessageCommandRequest:IRequest<Unit>
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid GroupChatId { get; set; }
    }
}
