namespace RealTimeChatApp.UI.Auth.Interfaces
{
    public interface IAuth
    {
        Task CheckAuthBeforeRequests();
        Task<string> GetClaim(string claimType);
    }
}
