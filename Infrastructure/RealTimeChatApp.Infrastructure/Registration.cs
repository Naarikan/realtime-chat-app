using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RealTimeChatApp.Application.Interfaces.Tokens;
using RealTimeChatApp.Infrastructure.Tokens;

namespace RealTimeChatApp.Infrastructure
{
    public static class Registration
    {
        public static void AddInsfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));//Options.ConfigurationExtensions kütüphanesi olmalı
            services.AddTransient<ITokenService, TokenService>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new()
                {

                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    ValidateLifetime = false,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero
                };


            }

           );

        }
    }
}
