using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Rachel.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(), //If a client requests profile as a scope (defined by IdentityResources)
            new IdentityResource("roles", 
                "Your role(s)", //displayed on consent screen 
                new [] {"role"}) //claims that must be returned when an application ask for this role scope
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            { };

    public static IEnumerable<Client> Clients =>
        new Client[] 
            { 
                new Client()
                {
                    ClientName = "Image Gallery",
                    ClientId = "imagegalleryclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris =
                    {
                        "https://localhost:7184/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:7184/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RequireConsent = true
                }
            };
}