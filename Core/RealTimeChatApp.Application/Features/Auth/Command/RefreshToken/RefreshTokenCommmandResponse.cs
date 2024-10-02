using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChatApp.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommmandResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
