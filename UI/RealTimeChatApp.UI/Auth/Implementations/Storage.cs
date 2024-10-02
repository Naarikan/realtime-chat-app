using Blazored.LocalStorage;
using RealTimeChatApp.UI.Auth.Interfaces;
using System.Security.Claims;

namespace RealTimeChatApp.UI.Auth.Implementations
{
    public class Storage:IStorage
    {
        ILocalStorageService _localStorageService;
        HttpClient _httpClient;

        public Storage(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
        }



        public async Task SetLocalStorage(string storageName, string token)
        {
            await _localStorageService.SetItemAsync(storageName, token);
        }

        public Guid GetUserId(List<Claim> claims)
        {
         
            var idClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            
            if (idClaim != null && Guid.TryParse(idClaim.Value, out Guid userId))
            {
                return userId; 
            }

            // Hata durumunda açıklayıcı bir hata mesajı fırlat
            throw new Exception("User ID could not be found or is not a valid GUID.");
        }
    }
}
