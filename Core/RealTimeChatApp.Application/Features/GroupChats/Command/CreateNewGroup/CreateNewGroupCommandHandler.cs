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

namespace RealTimeChatApp.Application.Features.GroupChats.Command.CreateNewGroup
{
    public class CreateNewGroupCommandHandler : BaseHandler, IRequestHandler<CreateNewGroupCommandRequest,Unit>
    {
        private readonly RoleManager<Role> _roleManager;

        public CreateNewGroupCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, RoleManager<Role> roleManager) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _roleManager = roleManager;
        }

        public async Task<Unit> Handle(CreateNewGroupCommandRequest request, CancellationToken cancellationToken)
        {
            GroupChat grpc = new(request.Name);
            

            
            await unitOfWork.GetWriteRepository<GroupChat>().AddAsync(grpc);
            await unitOfWork.SaveAsync();

            
            var role = await _roleManager.FindByNameAsync("admin");
            if (role == null)
                throw new Exception("Böyle bir rol bulunmamakta");

            Guid roleId = role.Id;

            
            UserGroupRole userGroupRole = new UserGroupRole
            {
                UserId = request.UserId,
                RoleId = roleId,
                GroupChatId = grpc.Id
            };

            
            await unitOfWork.GetWriteRepository<UserGroupRole>().AddAsync(userGroupRole);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
