using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RealTimeChatApp.Application.Features.GroupChats.Command.UseInviteCode
{
    public class UseInviteCodeCommandRequest:IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public string EncryptedCode { get; set; } 
    }
}
