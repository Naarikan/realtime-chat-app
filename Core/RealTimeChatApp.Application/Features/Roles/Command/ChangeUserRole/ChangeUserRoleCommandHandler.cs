using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealTimeChatApp.Application.Bases;
using RealTimeChatApp.Application.Interfaces.AutoMapper;
using RealTimeChatApp.Application.Interfaces.UnitOfWorks;
using RealTimeChatApp.Domain.Entities;

namespace RealTimeChatApp.Application.Features.Roles.Command.ChangeUserRole
{
	public class ChangeUserRoleCommandHandler : BaseHandler, IRequestHandler<ChangeUserRoleCommandRequest, Unit>
	{
		private readonly RoleManager<Role> _roleManager;

		public ChangeUserRoleCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, RoleManager<Role> roleManager) : base(mapper, unitOfWork, httpContextAccessor)
		{
			_roleManager = roleManager;
		}

		public async Task<Unit> Handle(ChangeUserRoleCommandRequest request, CancellationToken cancellationToken)
		{
			var userGroupRole = await unitOfWork.GetReadRepository<UserGroupRole>()
				.GetAsync(predicate: x => x.UserId == request.UserId && x.GroupChatId == request.GroupId, include: null);

			if (userGroupRole == null)
				throw new Exception("Kullanıcı grupta bulunamadı.");

			var role = await _roleManager.FindByNameAsync(request.NewRoleName);
			if (role == null)
				throw new Exception("Belirtilen Rol Bulunamadı");

			userGroupRole.RoleId = Guid.Empty;

			var roleId = role.Id;
			userGroupRole.RoleId = roleId;

			// Concurrency kontrolü
			try
			{
				await unitOfWork.GetWriteRepository<UserGroupRole>().UpdateAsync(userGroupRole);
				await unitOfWork.SaveAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				throw new Exception("Veri başka bir işlem tarafından değiştirildi, güncelleme başarısız.");
			}

			return Unit.Value;
		}

	}
}
