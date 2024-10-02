using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;


namespace RealTimeChatApp.UI.Provider
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService storageService;
        private HttpClient client;

        public CustomAuthStateProvider(ILocalStorageService storageService, HttpClient client)
        {
            this.storageService = storageService;
            this.client = client;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var jwtTokenFromLocalStorage = await storageService.GetItemAsync<string>("JwtToken");
            if (string.IsNullOrEmpty(jwtTokenFromLocalStorage))
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtTokenFromLocalStorage);


            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(jwtTokenFromLocalStorage), "JwtToken")));
        }



        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split(".")[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        public void NotifyUserAuthentication()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void NotifyUserLogout()
        {

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
        }
    }
}

