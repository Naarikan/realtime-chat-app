using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using RealTimeChatApp.Application.Bases;
using RealTimeChatApp.Application.Interfaces.AutoMapper;
using RealTimeChatApp.Application.Interfaces.UnitOfWorks;
using RealTimeChatApp.Domain.Entities;

namespace RealTimeChatApp.Application.Features.UserGroupRoles.Command.RemoveUserFromGroup
{
    public class RemoveUserFromGroupCommandHandler : BaseHandler, IRequestHandler<RemoveUserFromGroupCommandRequest, Unit>
    {
        public RemoveUserFromGroupCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(RemoveUserFromGroupCommandRequest request, CancellationToken cancellationToken)
        {
            var userGroupRole = await unitOfWork.GetReadRepository<UserGroupRole>().GetAsync(predicate:
                x=>x.UserId==request.UserId &&
                x.GroupChatId==request.GroupId,include:null);

            if (userGroupRole == null)
                throw new Exception("Kullancıı veya Grup mevcut değil");

            await unitOfWork.GetWriteRepository<UserGroupRole>().DestroyAsync(userGroupRole);

            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
