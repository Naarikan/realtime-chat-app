using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RealTimeChatApp.Application.Features.GroupChats.Command.CreateNewGroup
{
    public class CreateNewGroupCommandRequest:IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
