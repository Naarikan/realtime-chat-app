using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace RealTimeChatApp.Application.Features.UserGroupRoles.Command.AddUserToGroupWithRole
{
    public class AddUserToGroupWithRoleCommandValidator:AbstractValidator<AddUserToGroupWithRoleCommandRequest>
    {
        public AddUserToGroupWithRoleCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithName("Kullanıcı");
            RuleFor(y=>y.GroupChatId)
                .NotEmpty()
                .WithName("Grup");
        }
    }
}
