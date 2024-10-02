using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using RealTimeChatApp.UI.Auth.Interfaces;

namespace RealTimeChatApp.UI.Auth.Implementations
{
    public class Auth:IAuth
    {
        AuthenticationStateProvider _authenticationStateProvider;
        NavigationManager _navigationManager;

        public Auth(AuthenticationStateProvider authenticationStateProvider, NavigationManager navigationManager)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _navigationManager = navigationManager;
        }
        public async Task CheckAuthBeforeRequests()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            if (!user.Identity.IsAuthenticated)
            {
                _navigationManager.NavigateTo("/login");
                return;
            }
        }


        public async Task<string> GetClaim(string claimType)
        {

            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            var claim = user.Claims.FirstOrDefault(c => c.Type == claimType);
            return claim!.Value.ToString();
        }
    }
}
