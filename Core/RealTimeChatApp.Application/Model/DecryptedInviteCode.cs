using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChatApp.Application.Model
{
    public class DecryptedInviteCode
    {
        public Guid GroupId { get; set; }
        public int MaxUsage { get; set; }
    }
}
