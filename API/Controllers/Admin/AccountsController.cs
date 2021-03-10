using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace API.Controllers.Admin
{
  [ApiController]
  [Route("api/admin/[controller]")]
  public class AccountsController : ControllerBase
  {
    private readonly UserManager<AppUser> _userManager;
    public AccountsController(UserManager<AppUser> userManager)
    {
      _userManager = userManager;

    }

    [HttpGet]
    public async Task<ActionResult> listUsers()
    {
      var users = _userManager.Users;
      var formattedUsers = new List<API.DTOs.UserDto> { };
      foreach (var user in users)
      {
        var roles = await _userManager.GetRolesAsync(user);
        formattedUsers.Add(CreateUserObject(user, roles));
      }
      return Ok(formattedUsers);
    }

    [HttpPost("{id}")]
    public async Task<ActionResult> updateUser(string id, API.DTOs.UserDto updatedUser)
    {
      var user = await _userManager.FindByIdAsync(id);
      var roles = await _userManager.GetRolesAsync(user);

      // update displayName
      if (updatedUser.DisplayName != null && updatedUser.DisplayName != user.DisplayName)
      {
        user.DisplayName = updatedUser.DisplayName;
      }
      // prevent admin from de promoting himself
      var userEmailFromToken = HttpContext.User.FindFirstValue(ClaimTypes.Email);
      if (updatedUser.Email != userEmailFromToken || updatedUser.Roles.Contains("admin"))
      {
        await _userManager.RemoveFromRolesAsync(user, roles);
        await _userManager.AddToRolesAsync(user, updatedUser.Roles);
      }
      await _userManager.UpdateAsync(user);
      return Ok();
    }




    private API.DTOs.UserDto CreateUserObject(AppUser user, IList<string> roles)
    {
      return new API.DTOs.UserDto
      {
        Id = user.Id,
        DisplayName = user.DisplayName,
        Email = user.Email,
        Roles = roles
      };
    }


  }
}