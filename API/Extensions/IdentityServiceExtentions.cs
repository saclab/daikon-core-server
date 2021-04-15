using System.Text;
using API.Policies;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace API.Extensions
{
  public static class IdentityServiceExtentions
  {
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
      // IdentityBuilder builder = services.AddIdentityCore<AppUser>();


      services.AddScoped<IAuthorizationHandler, RequireAppRoleHandler>();

      services.AddIdentityCore<AppUser>()
      .AddRoles<AppRole>()
      .AddEntityFrameworkStores<DataContext>()

      .AddSignInManager<SignInManager<AppUser>>()

      .AddRoleManager<RoleManager<AppRole>>()
      .AddDefaultTokenProviders();

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
        options.Authority = config["Authority"];
        options.TokenValidationParameters = new TokenValidationParameters()
        {
          ValidAudience = config["ValidAudience"]
        };
      });

      // services.AddScoped<TokenService>();


      services.AddAuthorization(options =>
      {
        options.AddPolicy("RequireAdministratorRole",
            policy => policy.Requirements.Add(new RequireAppRole("admin")));

        options.AddPolicy("RequireUserRole",
            policy => policy.Requirements.Add(new RequireAppRole("user")));
      });

      return services;
    }
  }
}