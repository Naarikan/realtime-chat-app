﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RealTimeChatApp.Application.Features.Auth.Command.Register
{
    public class RegisterCommandRequest:IRequest<Unit>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassford { get; set; }
    }
}
