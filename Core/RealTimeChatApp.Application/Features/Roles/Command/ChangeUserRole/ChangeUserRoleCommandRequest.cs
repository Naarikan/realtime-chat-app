using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RealTimeChatApp.Application.Features.Roles.Command.ChangeUserRole
{
	public class ChangeUserRoleCommandRequest:IRequest<Unit>
	{
		public Guid UserId { get; set; }
		public Guid GroupId { get; set; }
		public string NewRoleName { get; set; }
	}
}
