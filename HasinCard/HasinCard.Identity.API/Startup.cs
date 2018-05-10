using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HasinCard.Data;
using HasinCard.Identity.API.Configuration;
using HasinCard.Service.SysUser;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HasinCard.Identity.API
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
            services.AddDbContext<HasinCardDbContext>(options => options.UseMySql(Configuration.GetConnectionString("Default")));
            services.AddScoped<ISysUserService, SysUserService>();

            // Build an intermediate service provider
            var sp = services.BuildServiceProvider();
            var sysUserService = sp.GetService<ISysUserService>();
            Config config = new Config(sysUserService);

            // configure identity server with in-memory stores, keys, clients and scopes
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(config.GetIdentityResources())
                .AddInMemoryApiResources(config.GetApiResources())
                .AddInMemoryClients(config.GetClients())
                .AddTestUsers(config.GetUsers());

            services.AddCors(options =>
            {
                //允许任何站点跨域
                options.AddPolicy("any", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
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
            //启用跨域
            app.UseCors("any");
            //启用身份验证
            app.UseIdentityServer();
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
