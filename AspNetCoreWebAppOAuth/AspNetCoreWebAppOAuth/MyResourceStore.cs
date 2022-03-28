using IdentityServer4.Models;
using IdentityServer4.Stores;

public class MyResourceStore : IResourceStore
{
    public Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
    {
        return Task.FromResult(new ApiResource[0].AsEnumerable());
    }

    public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
    {
        return Task.FromResult(new ApiResource[0].AsEnumerable());
    }

    public Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
    {
        return Task.FromResult(new ApiScope[0].AsEnumerable());
    }

    public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
    {
        return Task.FromResult(new IdentityResource[0].AsEnumerable());
    }

    public Task<Resources> GetAllResourcesAsync()
    {
        return Task.FromResult(
            new Resources(
                new IdentityResource[]
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                },
                new ApiResource[0],
                new ApiScope[0]
                )
            );
    }
}