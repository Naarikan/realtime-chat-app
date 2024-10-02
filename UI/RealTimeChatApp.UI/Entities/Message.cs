namespace RealTimeChatApp.UI.Entities
{
    public class Message
    {
        public string Content { get; set; }
        public Guid GroupChatId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UserName { get; set; }
       

    }
}
