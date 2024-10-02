using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RealTimeChatApp.Application.Features.Roles.Queries.GetUserRoleInGroup
{
	public class GetUserRoleInGroupQueryRequest:IRequest<GetUserRoleInGroupQueryResponse>
	{
		public Guid UserId { get; set; }
		public Guid GroupId { get; set; }
	}
}
