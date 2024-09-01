using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RealTimeChatApp.Application.Bases;
using RealTimeChatApp.Application.Interfaces.AutoMapper;
using RealTimeChatApp.Application.Interfaces.UnitOfWorks;
using RealTimeChatApp.Domain.Entities;

namespace RealTimeChatApp.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        public RegisterCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {

            User user = mapper.Map<User, RegisterCommandRequest>(request);
            user.SecurityStamp = Guid.NewGuid().ToString();
            bool hasUserWithEmail = (await unitOfWork.GetReadRepository<User>().GetAllAsync()).Any(x => x.Email == request.Email);
            if (hasUserWithEmail)
                throw new Exception("Böyle bir mail zaten mevcut,başka mail deneyiniz");
            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Kullanıcı Oluşturulamadı: {errors}");
            }

            return Unit.Value;
        }
    }
}
