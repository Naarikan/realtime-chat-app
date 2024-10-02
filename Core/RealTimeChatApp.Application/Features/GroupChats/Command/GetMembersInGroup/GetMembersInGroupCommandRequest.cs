using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RealTimeChatApp.Application.Features.GroupChats.Command.GetMembersInGroup
{
	public class GetMembersInGroupCommandRequest:IRequest<IList<GetMembersInGroupCommandResponse>>
	{
		public Guid GroupId { get; set; }
	}
}
