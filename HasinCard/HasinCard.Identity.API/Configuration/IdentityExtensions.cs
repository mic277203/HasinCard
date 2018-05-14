using CustomIdentityServer4.UserServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasinCard.Identity.API.Configuration
{
    public static class HasinIdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddHasinUserStore(this IIdentityServerBuilder builder)
        {
            builder.AddProfileService<HasinProfileService>();
            builder.AddResourceOwnerValidator<HasinResourceOwnerPasswordValidator>();

            return builder;
        }
    }
}
