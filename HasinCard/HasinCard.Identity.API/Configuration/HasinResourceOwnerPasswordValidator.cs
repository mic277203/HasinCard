using HasinCard.Service.SysUser;
using IdentityModel;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasinCard.Identity.API.Configuration
{
    public class HasinResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly ISysUserService _sysUserService;

        public HasinResourceOwnerPasswordValidator(ISysUserService sysUserService)
        {
            _sysUserService = sysUserService;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (_sysUserService.ValidateCredentials(context.UserName, context.Password))
            {
                var user = _sysUserService.FindByUsername(context.UserName);
                context.Result = new GrantValidationResult(user.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
            }

            return Task.FromResult(0);
        }
    }
}
