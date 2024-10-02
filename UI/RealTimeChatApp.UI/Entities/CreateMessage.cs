namespace RealTimeChatApp.UI.Entities
{
    public class CreateMessage
    {
        public CreateMessage()
        {
            
        }
        public CreateMessage(string content, Guid userId, Guid groupChatId)
        {
            Content = content;
            UserId = userId;
            GroupChatId = groupChatId;
        }

        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid GroupChatId { get; set; }
    }
}
