using RealTimeChatApp.Domain.Enums;

namespace RealTimeChatApp.Application.DTOs
{
    public class MessageDto
    {
       public string Content { get; set; }
       public Guid? GroupChatId { get; set; }
       public DateTime CreatedDate { get; set; }
       public  UserMessageDto Users { get; set; }
    }
}
