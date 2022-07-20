using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace API.Policies
{
  public class RequireAppRoleHandler : AuthorizationHandler<RequireAppRole>
  {
    private readonly UserManager<AppUser> _userManager;
    public RequireAppRoleHandler(UserManager<AppUser> userManager)
    {
      _userManager = userManager;
    }
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RequireAppRole requirement)
    {
      try
      {
        var userEmailFromToken = context.User.FindFirstValue(ClaimTypes.Email);
        var user = await _userManager.FindByEmailAsync(userEmailFromToken);
        var roles = await _userManager.GetRolesAsync(user);
        if (roles.Contains(requirement.RoleName) || roles.Contains("admin"))
        {
          context.Succeed(requirement);
        }

      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}