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

namespace RealTimeChatApp.Application.Features.UserGroupRoles.Queries.GetAllGroupsWithLastMessage
{
    public class GetAllGroupsWithLastMessageQueryHandler : BaseHandler, IRequestHandler<GetAllGroupsWithLastMessageQueryRequest, IList<GetAllGroupsWithLastMessageQueryResponse>>
    {
        public GetAllGroupsWithLastMessageQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllGroupsWithLastMessageQueryResponse>> Handle(GetAllGroupsWithLastMessageQueryRequest request, CancellationToken cancellationToken)
        {
            var groupChats = await unitOfWork.GetReadRepository<UserGroupRole>().GetAllAsync(predicate:x=>x.UserId==request.UserId,
            include:y=>y.Include(z=>z.GroupChat).Include(r=>r.Role));

            var groupChat = mapper.Map<GroupChatDto, GroupChat>(new GroupChat());
            var role = mapper.Map<RoleDto, Role>(new Role());   

            var map = mapper.Map<GetAllGroupsWithLastMessageQueryResponse, UserGroupRole>(groupChats);

            return map;
        }
    }
    }

