using System;
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
      // Console.WriteLine("*************************** ENVIRONMENT CONFIG *****************");
      // Console.WriteLine("Authority : " + Environment.GetEnvironmentVariable("AZURE_AUTHORITY"));
      // Console.WriteLine("ValidAudience : " + Environment.GetEnvironmentVariable("AZURE_VALID_AUDIENCE"));


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
        options.Authority = Environment.GetEnvironmentVariable("AZURE_AUTHORITY");
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            //ValidAudience = Environment.GetEnvironmentVariable("AZURE_VALID_AUDIENCE")
            ValidateAudience = false
        };
      });

      // services.AddScoped<TokenService>();


      services.AddAuthorization(options =>
      {
        options.AddPolicy("RequireAdministratorRole",
            policy => policy.Requirements.Add(new RequireAppRole("admin")));

        options.AddPolicy("RequireUserRole",
            policy => policy.Requirements.Add(new RequireAppRole("user")));

        options.AddPolicy("RequireProjectManagerRole",
            policy => policy.Requirements.Add(new RequireAppRole("projectManager")));

        options.AddPolicy("RequireScreenerRole",
            policy => policy.Requirements.Add(new RequireAppRole("screener")));

        options.AddPolicy("RequireVoterRole",
            policy => policy.Requirements.Add(new RequireAppRole("voter")));
      });

      return services;
    }
  }
}