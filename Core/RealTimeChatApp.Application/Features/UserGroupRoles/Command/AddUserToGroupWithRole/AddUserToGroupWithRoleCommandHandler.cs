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

namespace RealTimeChatApp.Application.Features.UserGroupRoles.Command.AddUserToGroupWithRole
{
    public class AddUserToGroupWithRoleCommandHandler : BaseHandler, IRequestHandler<AddUserToGroupWithRoleCommandRequest, Unit>
    {
        private readonly RoleManager<Role> _roleManager;

        public AddUserToGroupWithRoleCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, RoleManager<Role> roleManager) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _roleManager = roleManager;
        }

        public async Task<Unit> Handle(AddUserToGroupWithRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByNameAsync("member");
            if (role == null)
                throw new Exception("Bu isimde bir role bulunmamaktadır");
            var roleId=role.Id;

            UserGroupRole ugr = new(request.UserId,roleId,request.GroupChatId);

            await unitOfWork.GetWriteRepository<UserGroupRole>().AddAsync(ugr);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
