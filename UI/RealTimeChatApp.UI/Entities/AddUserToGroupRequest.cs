namespace RealTimeChatApp.UI.Entities
{
	public class AddUserToGroupRequest
	{
		public string Email { get; set; }
		public Guid GroupChatId { get; set; }
	}
}
