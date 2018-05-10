using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HasinCard.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //关闭了JWT声明类型映射，以允许众所周知的声明（例如'sub'和'idp'）通过不受干扰的
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            // AddAuthentication将认证服务添加到DI。作为主装置来验证用户（通过我们使用一个cookie "Cookies"为DefaultScheme）。我们设置为DefaultChallengeScheme，"oidc"因为当我们需要用户登录时，我们将使用OpenID Connect方案。

            //然后我们使用AddCookie添加可以处理cookie的处理程序。

            //最后，AddOpenIdConnect用于配置执行OpenID Connect协议的处理程序。这Authority表明我们正在信任IdentityServer。然后我们通过ClientId。 SignInScheme用于在OpenID Connect协议完成后使用cookie处理程序发布cookie。并SaveTokens用于在cookie中保存来自IdentityServer的令牌（因为它们将在稍后需要）。
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = "Cookies";
            //    options.DefaultChallengeScheme = "oidc";
            //})
            //    .AddCookie("Cookies")
            //    .AddOpenIdConnect("oidc", options =>
            //    {
            //        options.SignInScheme = "Cookies";

            //        options.Authority = "http://localhost:5680/";
            //        options.RequireHttpsMetadata = false;

            //        options.ClientId = "mvc";
            //        options.SaveTokens = true;
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
