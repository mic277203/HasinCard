using HasinCard.Service.SysUser;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasinCard.Identity.API.Configuration
{
    public class Config
    {
        public IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        /// <summary>
        /// 获取客户端
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "swaggerui",
                    ClientName = "Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { "http://localhost:11415/swagger/o2c.html" },
                    PostLogoutRedirectUris = { "http://localhost:11415/swagger/" },

                    AllowedScopes =
                    {
                       "apihost"
                    }
                },
                // app client
                 new Client
                {
                    ClientId = "app",
                    
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "apihost" }
                },
                // JavaScript Client
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://localhost:7762/SignCallBack" },
                    PostLogoutRedirectUris = { "http://localhost:7762/Home" },
                    AllowedCorsOrigins =     { "http://localhost:7762" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "apihost"
                    }
                }
             };
        }

        /// <summary>
        /// 定义API资源
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("apihost", "My Host API")
            };
        }
    }
}
