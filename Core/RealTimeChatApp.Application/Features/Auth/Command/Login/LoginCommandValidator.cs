using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace RealTimeChatApp.Application.Features.Auth.Command.Login
{
    public class LoginCommandValidator:AbstractValidator<LoginCommandRequest>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithName("Mail");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithName("Şifre");
        }
    }
}
