using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RealTimeChatApp.Application.Bases;
using RealTimeChatApp.Application.DTOs;
using RealTimeChatApp.Application.Interfaces.AutoMapper;
using RealTimeChatApp.Application.Interfaces.UnitOfWorks;
using RealTimeChatApp.Domain.Entities;

namespace RealTimeChatApp.Application.Features.Messages.Queries.GetGroupMessages
{
    public class GetAllMessagesQueryHandler : BaseHandler, IRequestHandler<GetAllMessagesQueryRequest, IList<GetAllMessagesQueryResponse>>
    {
        public GetAllMessagesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllMessagesQueryResponse>> Handle(GetAllMessagesQueryRequest request, CancellationToken cancellationToken)
        {
            var messages = await unitOfWork.GetReadRepository<Message>().GetAllAsync(include: x => x.Include(b => b.User),orederedBy:q => q.OrderBy(m => m.CreatedDate));

            var user = mapper.Map<UserMessageDto, User>(new User());

            var map = mapper.Map<GetAllMessagesQueryResponse,Message>(messages);
            return map;
        }
    }
}
