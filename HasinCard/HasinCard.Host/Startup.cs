using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HasinCard.Core.AuoMapper;
using HasinCard.Core.Validator.SysUser;
using HasinCard.Data;
using HasinCard.Service.SysUser;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using IdentityServer4.AccessTokenValidation;

namespace HasinCard.Host
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
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDbContext<HasinCardDbContext>(options => options.UseMySql(Configuration.GetConnectionString("Default")));
            services.AddScoped<ISysUserService, SysUserService>();

            services.AddAuthentication("Bearer")
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = "http://149.28.31.100:800";
                options.RequireHttpsMetadata = false;
                options.ApiName = "apihost";
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Hain API", Version = "v1" });

                // Handle OAuth
                options.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "implicit",
                    AuthorizationUrl = "http://149.28.31.100:800/connect/authorize",
                    TokenUrl = "http://149.28.31.100:800/connect/token",
                    Scopes = new Dictionary<string, string>()
                    {
                        { "apihost", "hasin api" }
                    }
                });

                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });

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
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hasin API V1");
                c.ConfigureOAuth2("swaggerui", "", "", "Swagger UI");
            });

            app.UseCors("any");
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
