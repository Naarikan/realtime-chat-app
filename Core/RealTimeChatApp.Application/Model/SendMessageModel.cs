using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChatApp.Application.Model
{
    public class SendMessageModel
    {
        public string GroupChatId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
       
    }
}
