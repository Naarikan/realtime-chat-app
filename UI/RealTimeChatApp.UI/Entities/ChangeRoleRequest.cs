namespace RealTimeChatApp.UI.Entities
{
    public class ChangeRoleRequest
    {
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
        public string NewRoleName { get; set; }
    }
}
