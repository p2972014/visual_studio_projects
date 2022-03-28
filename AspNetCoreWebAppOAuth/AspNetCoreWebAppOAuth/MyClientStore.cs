using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace AspNetCoreWebAppOAuth
{
    public class MyClientStore : IClientStore
    {
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            return Task.FromResult(
                new Client
                {
                    ClientId = "clientId",
                    ClientName = "name_from_id_"+ clientId,

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    //ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) }
                    //,

                    //AllowedScopes = { "scope1" }
                }
                );
        }
    }
}
