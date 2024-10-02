namespace RealTimeChatApp.UI.Entities
{
	public class GetUserRoleRequest
	{
		public Guid UserId { get; set; }
		public Guid GroupId { get; set; }
	}
}
