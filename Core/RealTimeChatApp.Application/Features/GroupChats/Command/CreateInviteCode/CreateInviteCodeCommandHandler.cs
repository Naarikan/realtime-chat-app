using MediatR;
using Microsoft.AspNetCore.Http;
using RealTimeChatApp.Application.Bases;
using RealTimeChatApp.Application.Encryption;
using RealTimeChatApp.Application.Interfaces.AutoMapper;
using RealTimeChatApp.Application.Interfaces.UnitOfWorks;
using RealTimeChatApp.Domain.Entities;

namespace RealTimeChatApp.Application.Features.GroupChats.Command.CreateInviteCode
{
    public class CreateInviteCodeCommandHandler : BaseHandler, IRequestHandler<CreateInviteCodeCommandRequest, CreateInviteCodeCommandResponse>
    {
       private readonly InviteCodeManager _inviteCodeManager;

        public CreateInviteCodeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, InviteCodeManager inviteCodeManager) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _inviteCodeManager = inviteCodeManager;
        }

        public async Task<CreateInviteCodeCommandResponse> Handle(CreateInviteCodeCommandRequest request, CancellationToken cancellationToken)
        {
            CreateInviteCodeCommandResponse ic = new();

            InviteCode ınviteCode = new InviteCode()
            {
                EncryptedCode = _inviteCodeManager.CreateInviteCode(request.GroupId),
                MaxUsage = request.maxUsage

            };

            await unitOfWork.GetWriteRepository<InviteCode>().AddAsync(ınviteCode);
            await unitOfWork.SaveAsync();

            ic.EncryptedCode=ınviteCode.EncryptedCode;

            return ic;
           
        }
    }
}
