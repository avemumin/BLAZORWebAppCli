using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SGNWebAppCli.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        // Zmiana z sessionstorage na local
        // private ISessionStorageService _sessionStorageService;
        private ILocalStorageService _localStorageService;
        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var emailAddress = await _localStorageService.GetItemAsync<string>("emailAddress");
            ClaimsIdentity identity;
            if (emailAddress != null)
            {
                identity = new ClaimsIdentity(new[]
               {
                    new Claim(ClaimTypes.Name,emailAddress),
                }, "apiauth_type");
            }
            else
            {
                identity = new ClaimsIdentity();
            }


            var user = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(user));
        }

        public void MarkUserAsAuthenticated(string emailAddress)
        {
            var identity = new ClaimsIdentity(new[]
           {
                new Claim(ClaimTypes.Name,emailAddress),
            }, "apiauth_type");

            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsLoggedOut()
        {
            _localStorageService.RemoveItemAsync("accessToken");
            _localStorageService.RemoveItemAsync("refreshToken");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
