using RealTimeChatApp.Domain.Common;
using RealTimeChatApp.Domain.Enums;

namespace RealTimeChatApp.Domain.Entities
{
    public class Message:EntityBase
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }//-->sender ıd
        public User User { get; set; }//--> sender

        ChatStatus ChatStatus { get; set; }


        public Guid? GroupChatId { get; set; }
        public GroupChat? GroupChat { get; set; }

        public Guid? PrivateChatId { get; set; }
        PrivateChat? PrivateChat { get; set; }
        
       
    }
}
