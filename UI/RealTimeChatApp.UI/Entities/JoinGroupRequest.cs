namespace RealTimeChatApp.UI.Entities
{
    public class JoinGroupRequest
    {
        public Guid UserId { get; set; }
        public string EncryptedCode { get; set; }
    }
}
