using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChatApp.Application.DTOs
{
    public class GroupChatWithLastMessageDto
    {
        public string Name { get; set; }
        public MessageDto Message { get; set; }

    }
}
