using System.Security.Claims;

namespace RealTimeChatApp.UI.Auth.Interfaces
{
    public interface IStorage
    {
        Task SetLocalStorage(string storageName, string token);
        Guid GetUserId(List<Claim> claims);
    }
}
