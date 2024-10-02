namespace RealTimeChatApp.UI.Entities
{
    public class SendMessageModel
    {
       
        public string UserName { get; set; }
        public string Content { get; set; }
        public string GroupChatId { get; set; }
        public DateTime Date { get; set; }
    }
}
