using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RealTimeChatApp.Application.Bases;
using RealTimeChatApp.Application.Interfaces.AutoMapper;
using RealTimeChatApp.Application.Interfaces.UnitOfWorks;
using RealTimeChatApp.Domain.Entities;

namespace RealTimeChatApp.Application.Features.Roles.Queries.GetUserRoleInGroup
{
	public class GetUserRoleInGroupQueryHandler : BaseHandler, IRequestHandler<GetUserRoleInGroupQueryRequest, GetUserRoleInGroupQueryResponse>
	{
		private readonly RoleManager<Role> roleManager;
		public GetUserRoleInGroupQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, RoleManager<Role> roleManager) : base(mapper, unitOfWork, httpContextAccessor)
		{
			this.roleManager = roleManager;
		}

		public async Task<GetUserRoleInGroupQueryResponse> Handle(GetUserRoleInGroupQueryRequest request, CancellationToken cancellationToken)
		{
			var userGroupRole = await unitOfWork.GetReadRepository<UserGroupRole>().GetAsync(predicate:x=>x.GroupChatId==request.GroupId && x.UserId==request.UserId,
				include:null);

			var role = await roleManager.FindByIdAsync(userGroupRole.RoleId.ToString());

			var map = mapper.Map<GetUserRoleInGroupQueryResponse,Role>(role);
			return map;
		}
	}
}
