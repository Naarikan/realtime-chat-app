using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RealTimeChatApp.Application.Features.UserGroupRoles.Queries.GetAllGroupsWithLastMessage
{
    public class GetAllGroupsWithLastMessageQueryRequest:IRequest<IList<GetAllGroupsWithLastMessageQueryResponse>>
    {
      public Guid UserId { get; set; }
    }
}
