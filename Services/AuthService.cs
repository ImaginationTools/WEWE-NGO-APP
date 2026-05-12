using Microsoft.Identity.Client;
using System.Threading.Tasks;

namespace WEWE.Maui.Services
{
    public class AuthService
    {
        private readonly IPublicClientApplication _pca;
        private readonly string[] _scopes = { "User.Read" };

        public AuthService(string clientId, string tenantId)
        {
            _pca = PublicClientApplicationBuilder.Create(clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
                .WithRedirectUri("http://localhost")
                .Build();
        }

        public async Task<AuthenticationResult> LoginAsync()
        {
            try
            {
                var accounts = await _pca.GetAccountsAsync();
                return await _pca.AcquireTokenSilent(_scopes, accounts.FirstOrDefault())
                                 .ExecuteAsync();
            }
            catch
            {
                return await _pca.AcquireTokenInteractive(_scopes)
                                 .ExecuteAsync();
            }
        }
    }
}