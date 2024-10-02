using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RealTimeChatApp.Application.Features.Messages.Queries.GetGroupMessages
{
    public class GetAllMessagesQueryRequest:IRequest<IList<GetAllMessagesQueryResponse>>
    {
    }
}
