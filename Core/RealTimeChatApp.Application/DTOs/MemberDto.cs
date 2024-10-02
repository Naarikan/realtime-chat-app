using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChatApp.Application.DTOs
{
	public class MemberDto
	{
		public UserMessageDto UserMessage { get; set; }
		public RoleDto Role { get; set; }
	}
}
