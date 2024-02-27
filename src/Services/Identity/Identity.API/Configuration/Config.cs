using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;

namespace Identity.API.Configuration;

public class Config
{
    /* Scope is a core feature of OAuth that allows you to express the extent or scope of access. 
       Clients request scopes when they initiate the protocol, declaring what scope of access they want. 
       IdentityServer then has to decide which scopes to include in the token. 
       Just because the client has asked for something doesn’t mean they should get it! 
       There are built-in abstractions as well as extensibility points that you can use to make this decision. 
       Ultimately, IdentityServer issues a token to the client, which then uses the token to access APIs. 
       APIs can check the scopes that were included in the token to make authorization decisions.
       Scopes don’t have structure imposed by the protocols - they are just space-separated strings. 
       This allows for flexibility when designing the scopes used by a system. */
    public static IEnumerable<ApiScope> ApiScopes =>
    [
        new ApiScope("catalog_api", "Catalog API")
    ];


    // Configure a client application that will be used to access the API.
    public static IEnumerable<Client> Clients =>
    [
        new Client
        {
            ClientId = "sanau_mvc",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = 
            {
                new Secret("secret".Sha256())
            },
            AllowedScopes = { "catalog_api" }
        }
    ];

    public static IEnumerable<ApiResource> ApiResources => [];

    // Similar to OAuth, OpenID Connect uses scopes to represent something you want to protect and that clients want to access. 
    // In contrast to OAuth, scopes in OIDC represent identity data like user id, name or email address rather than APIs.
    public static IEnumerable<IdentityResource> IdentityResources => [];

    // We can use those users to login. Note that the test users' passwords match their usernames.
    public static List<TestUser> TestUsers => [];
}