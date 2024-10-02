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

namespace RealTimeChatApp.Application.Features.GroupChats.Command.AddUserToGroup
{
    public class AddUserToGroupCommandHandler : BaseHandler, IRequestHandler<AddUserToGroupCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public AddUserToGroupCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, RoleManager<Role> roleManager) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Unit> Handle(AddUserToGroupCommandRequest request, CancellationToken cancellationToken)
        {
           var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new Exception("Kullanıcı Bulunamadı");

            var role = await roleManager.FindByNameAsync("member");
            if (role == null) throw new Exception("Rol Bulunamadı");

            UserGroupRole userGroupRole = new(user.Id,role.Id,request.GroupChatId);
            await unitOfWork.GetWriteRepository<UserGroupRole>().AddAsync(userGroupRole);
            await unitOfWork.SaveAsync();
            return Unit.Value;


        }
    }
}
