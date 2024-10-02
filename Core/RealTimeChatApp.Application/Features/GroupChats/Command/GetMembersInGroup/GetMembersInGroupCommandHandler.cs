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

namespace RealTimeChatApp.Application.Features.GroupChats.Command.GetMembersInGroup
{
	public class GetMembersInGroupCommandHandler : BaseHandler, IRequestHandler<GetMembersInGroupCommandRequest, IList<GetMembersInGroupCommandResponse>>
	{
		public GetMembersInGroupCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
		{
		}

		public async Task<IList<GetMembersInGroupCommandResponse>> Handle(GetMembersInGroupCommandRequest request, CancellationToken cancellationToken)
		{
			var members = await unitOfWork.GetReadRepository<UserGroupRole>().GetAllAsync(predicate:x=>x.GroupChatId==request.GroupId,
				include:x=>x.Include(y=>y.User).Include(z=>z.Role));

			var user = mapper.Map<UserMessageDto, User>(new User());

			var role = mapper.Map<RoleDto, Role>(new Role());

			var map = mapper.Map<GetMembersInGroupCommandResponse, UserGroupRole>(members);

			return map;

		}
	}
}
