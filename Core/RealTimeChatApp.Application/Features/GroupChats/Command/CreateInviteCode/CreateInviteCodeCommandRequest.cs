using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RealTimeChatApp.Application.Features.GroupChats.Command.CreateInviteCode
{
    public class CreateInviteCodeCommandRequest:IRequest<CreateInviteCodeCommandResponse>
    {
       
        public Guid GroupId { get; set; }
        public int maxUsage { get; set; }
    }
}
