using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
    {
        new ApiResource("game")
    };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
             {
        new TestUser
        {
            SubjectId = "1",
            Username = "alice",
            Password = "password"
        },
        new TestUser
        {
            SubjectId = "2",
            Username = "bob",
            Password = "password"
        }
    };
        }

        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
                 {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),

            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
    {
        new Client
        {
            ClientId = "App",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            RequireConsent = false,
            AccessTokenLifetime = 3600 * 2,
            RequireClientSecret = false,
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },
            AllowedScopes = { "game" },
            AllowedCorsOrigins =     { "http://localhost:4200"},

        }
        };
        }

    }
}
