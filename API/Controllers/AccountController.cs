using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Services;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    private readonly IUserAccessor _userAccessor;
    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserAccessor userAccessor)
    {
      _userAccessor = userAccessor;
      _signInManager = signInManager;
      _userManager = userManager;
    }

    // [HttpPost("login")]
    // public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    // {
    //   var user = await _userManager.FindByEmailAsync(loginDto.Email);

    //   if (user == null) return Unauthorized();

    //   var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

    //   if (result.Succeeded)
    //   {
    //     return CreateUserObject(user);
    //   }

    //   return Unauthorized();

    // }

    [HttpGet]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
      var userEmailFromToken = HttpContext.User.FindFirstValue(ClaimTypes.Email);
      var user = await _userManager.FindByEmailAsync(userEmailFromToken);

      var roles = await _userManager.GetRolesAsync(user);

      if (user == null) return null;

      

      return CreateUserObject(user);

    }

    private UserDto CreateUserObject(AppUser user)
    {
      return new UserDto
      {
        DisplayName = user.DisplayName,
        Email = user.Email,
        Username = user.UserName
      };
    }

  }
}