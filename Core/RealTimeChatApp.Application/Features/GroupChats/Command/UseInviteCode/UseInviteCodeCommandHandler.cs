using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RealTimeChatApp.Application.Bases;
using RealTimeChatApp.Application.Encryption;
using RealTimeChatApp.Application.Interfaces.AutoMapper;
using RealTimeChatApp.Application.Interfaces.UnitOfWorks;
using RealTimeChatApp.Domain.Entities;

namespace RealTimeChatApp.Application.Features.GroupChats.Command.UseInviteCode
{
    public class UseInviteCodeCommandHandler : BaseHandler, IRequestHandler<UseInviteCodeCommandRequest, Unit>
    {
       private readonly InviteCodeManager ınviteCodeManager;
        private readonly RoleManager<Role> roleManager;

        public UseInviteCodeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, InviteCodeManager ınviteCodeManager, RoleManager<Role> roleManager = null) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.ınviteCodeManager = ınviteCodeManager;
            this.roleManager = roleManager;
        }

        public async Task<Unit> Handle(UseInviteCodeCommandRequest request, CancellationToken cancellationToken)
        {
            var codes = await unitOfWork.GetReadRepository<InviteCode>().GetAllAsync(predicate:x=>x.EncryptedCode==request.EncryptedCode);

            if (codes == null || !codes.Any())
            {
                throw new InvalidOperationException("Davet kodu bulunamadı veya silinmiş.");
            }


            var code = codes.SingleOrDefault()!;

            if (code.MaxUsage==0 || code is null)
            {
                await unitOfWork.GetWriteRepository<InviteCode>().DestroyAsync(code);
                await unitOfWork.SaveAsync();
                throw new Exception("Davet kodunun kullanım sınırı dolmuş!");
            }

            var decryptedCode = ınviteCodeManager.DecryptInviteCode(request.EncryptedCode);

            code.MaxUsage -= 1;

            await unitOfWork.GetWriteRepository<InviteCode>().UpdateAsync(code);

            var groupId = decryptedCode.GroupId;
            var role = await roleManager.FindByNameAsync("member");

            UserGroupRole newGroupUser = new(request.UserId,role.Id,groupId);

            await unitOfWork.GetWriteRepository<UserGroupRole>().AddAsync(newGroupUser);

            await unitOfWork.SaveAsync();

            return Unit.Value;


        }
    }
}
