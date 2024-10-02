using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RealTimeChatApp.Application.Bases;
using RealTimeChatApp.Application.DTOs;
using RealTimeChatApp.Application.Interfaces.AutoMapper;
using RealTimeChatApp.Application.Interfaces.UnitOfWorks;
using RealTimeChatApp.Domain.Entities;

namespace RealTimeChatApp.Application.Features.UserGroupRoles.Queries.GetMessagesByGroup
{
    public class GetMessagesByGroupQueryHandler : BaseHandler, IRequestHandler<GetMessagesByGroupQueryRequest, IList<GetMessagesByGroupQueryResponse>>
    {
        public GetMessagesByGroupQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetMessagesByGroupQueryResponse>> Handle(GetMessagesByGroupQueryRequest request, CancellationToken cancellationToken)
        {
            var groupChatMessages = await unitOfWork.GetReadRepository<Message>().GetAllAsync(predicate:x=>x.GroupChatId==request.GroupChatId,
                include:x=>x.Include(b=>b.User),orederedBy:x=>x.OrderBy(y=>y.CreatedDate));
            var response = groupChatMessages.Select(message => new GetMessagesByGroupQueryResponse
            {
                Content = message.Content,
                CreatedDate = message.CreatedDate,
                UpdatedDate = message.UpdatedDate,
                UserName = message.User?.UserName 
            }).ToList();

            return response;


            
          
        }
    }
}
