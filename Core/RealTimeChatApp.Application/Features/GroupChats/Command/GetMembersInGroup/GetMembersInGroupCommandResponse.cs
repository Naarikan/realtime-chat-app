using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealTimeChatApp.Application.DTOs;

namespace RealTimeChatApp.Application.Features.GroupChats.Command.GetMembersInGroup
{
	public class GetMembersInGroupCommandResponse
	{
		public UserMessageDto User { get; set; }
		public RoleDto Role { get; set; }
	}
}
