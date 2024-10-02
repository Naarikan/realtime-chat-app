using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RealTimeChatApp.Application.Bases;
using RealTimeChatApp.Application.Interfaces.AutoMapper;
using RealTimeChatApp.Application.Interfaces.Tokens;
using RealTimeChatApp.Application.Interfaces.UnitOfWorks;
using RealTimeChatApp.Domain.Entities;

namespace RealTimeChatApp.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommmandRequest, RefreshTokenCommmandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        public RefreshTokenCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ITokenService tokenService) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
        }

        public async Task<RefreshTokenCommmandResponse> Handle(RefreshTokenCommmandRequest request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string email = principal.FindFirstValue(ClaimTypes.Email);

            User? user = await userManager.FindByEmailAsync(email);
            if (user is not null)
            {
                if (user.RefreshTokenExpiryTime <= DateTime.Now)
                    throw new Exception("Lütfen tekrar giriş yapınız");

                JwtSecurityToken newToken = await tokenService.CreateToken(user);

                string newRefreshToken = tokenService.GenerateRefreshToken();

                await userManager.UpdateAsync(user);

                return new()
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(newToken),
                    RefreshToken = newRefreshToken,
                };
            }
            else
                throw new Exception("Böyle bir kullanıcı bulunamadı!");

        }
    }
}
