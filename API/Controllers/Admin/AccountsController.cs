using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers.Admin
{
  [ApiController]
  [Route("api/admin/[controller]")]
  [Authorize(Policy = "RequireAdministratorRole")]
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


    [HttpPost]
    public async Task<ActionResult> createUser(API.DTOs.RegisterDto newUser)
    {

      // check if user exists
      var exists = await _userManager.FindByEmailAsync(newUser.Email);
      if (exists != null)
      {
        return BadRequest("User already exists");
      }

      // add the user

      var user = new AppUser
      {
        DisplayName = newUser.DisplayName,
        Email = newUser.Email,
        UserName = newUser.Email
      };

      var result = await _userManager.CreateAsync(user);

      if (!result.Succeeded)
      {
        return UnprocessableEntity("Failed to add new user");
      }
      result = await _userManager.AddToRolesAsync(user, newUser.Roles);
      if (!result.Succeeded)
      {
        return UnprocessableEntity("Failed to set roles for new user");
      }
      return Ok();
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
      if (updatedUser.Email == userEmailFromToken && !updatedUser.Roles.Contains("admin"))
      {
        return BadRequest("Admin cannot remove itself");
      }
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