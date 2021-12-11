using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MicroStruct.Services.Identity
{

    public static class SD
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResources.Phone(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
               new List<ApiScope>
               {
                   new ApiScope("microstruct","Micro Struct Server"),
                   new ApiScope("read","Read data"),
                   new ApiScope("write","Write data"),
                   new ApiScope("delete","Delete data")
               };
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
               new Client
                {
                    ClientId="client",
                    ClientSecrets= { new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes={ "read", "write","profile"}
                },
                new Client
                {
                    ClientId="microstruct",
                    ClientSecrets= { new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris={ "https://localhost:7012/signin-oidc" },
                    PostLogoutRedirectUris={"https://localhost:7012/signout-callback-oidc" },
                    AllowedScopes=new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        "microstruct"
                    }
                },
            };
    }

    public static class GlobalRoles
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
    }
}
