using RealTimeChatApp.Domain.Common;
using RealTimeChatApp.Domain.Enums;

namespace RealTimeChatApp.Domain.Entities
{
    public class Message:EntityBase
    {
        public Message()
        {
            
        }

        public Message(string content,Guid userId,ChatStatus status,Guid? groupChatId)
        {
            Content = content;
            UserId = userId;
            ChatStatus = status;
            
            GroupChatId = groupChatId;
        }
       

        public string Content { get; set; }
        public Guid UserId { get; set; }//-->sender ıd
        public User User { get; set; }//--> sender

        ChatStatus ChatStatus { get; set; }


        public Guid? GroupChatId { get; set; }
        public GroupChat? GroupChat { get; set; }

        
       
        
       
    }
}
