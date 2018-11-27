using AppServices.ServiceInterfaces;
using Authentication.AppServices.JwtAuthentication;
using Authentication.Contracts.JwtAuthentication.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AdsWebApi.Security
{
    public static class ServiceCollectionSecurityExtension
    {
        public static void JWTSecurityExtention(this IServiceCollection services, JwtServerAuthenticationOptions jwtOptions)
        {
            /// Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 0;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
            services.AddAuthentication(o =>
            {
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.Audience = jwtOptions.Audience;
                    options.ClaimsIssuer = jwtOptions.Issuer;
                    options.TokenValidationParameters = JwtDefaultsProvider.GetTokenValidationParameters(
                        jwtOptions.Issuer, jwtOptions.Audience, jwtOptions.Secret);
                });
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                 .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌)
                  .RequireAuthenticatedUser().Build());
            });
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.Events = new JwtBearerEvents
            //    {
            //        OnTokenValidated = context =>
            //        {
            //            var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
            //            var userId = int.Parse(context.Principal.Identity.Name);
            //            var user = userService.GetById(userId);
            //            if (user == null)
            //            {
            //                // return unauthorized if user no longer exists
            //                context.Fail("Unauthorized");
            //            }
            //            return Task.CompletedTask;
            //        }
            //    };
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey)),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});
        }
    }
}
