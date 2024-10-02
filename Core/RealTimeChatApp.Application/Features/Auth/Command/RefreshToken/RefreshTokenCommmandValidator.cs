using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace RealTimeChatApp.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommmandValidator : AbstractValidator<RefreshTokenCommmandRequest>
    {
        public RefreshTokenCommmandValidator()
        {
            RuleFor(x => x.AccessToken).NotEmpty();
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}
