using System.Text;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace API.Extensions
{
  public static class IdentityServiceExtentions
  {
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
      services.AddIdentityCore<AppUser>(opt =>
     {

     })
      .AddEntityFrameworkStores<DataContext>()
      .AddSignInManager<SignInManager<AppUser>>();

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
        options.Authority = config["Authority"];
        options.TokenValidationParameters = new TokenValidationParameters()
        {
          ValidAudience = config["ValidAudience"]
        };
      });
      services.AddScoped<TokenService>();

      return services;
    }
  }
}