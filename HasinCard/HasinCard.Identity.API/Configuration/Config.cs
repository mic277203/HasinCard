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
        private readonly ISysUserService _iSysUserService;
        public Config(ISysUserService sysUserService)
        {
            _iSysUserService = sysUserService;
        }
        public IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        public List<TestUser> GetUsers()
        {
            var listUsers = _iSysUserService.GetList();
            var listTestUsers = new List<TestUser>();

            listUsers.ForEach(p =>
            {
                listTestUsers.Add(new TestUser()
                {
                    SubjectId = p.Id.ToString(),
                    Username = p.Email,
                    Password = p.Password
                });
            });

            return listTestUsers;
        }

        /// <summary>
        /// 获取客户端
        /// </summary>
        /// <returns></returns>
        public  IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                // JavaScript Client
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://localhost:8957/callback.aspx" },
                    PostLogoutRedirectUris = { "http://localhost:8957/index.aspx" },
                    AllowedCorsOrigins =     { "http://localhost:8957" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "apiHost"
                    }
                }
             };
        }

        /// <summary>
        /// 定义API资源
        /// </summary>
        /// <returns></returns>
        public  IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("apiHost", "My Host API")
            };
        }
    }
}
