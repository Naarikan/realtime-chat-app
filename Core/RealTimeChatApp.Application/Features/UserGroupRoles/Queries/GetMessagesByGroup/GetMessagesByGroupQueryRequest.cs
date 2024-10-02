using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RealTimeChatApp.Application.Features.UserGroupRoles.Queries.GetMessagesByGroup
{
    public class GetMessagesByGroupQueryRequest:IRequest<IList<GetMessagesByGroupQueryResponse>>
    {
        public Guid GroupChatId { get; set; }
    }
}
