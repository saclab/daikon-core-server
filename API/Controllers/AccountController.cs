using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Services;
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
    private readonly TokenService _tokenService;
    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
    {
      _tokenService = tokenService;
      _signInManager = signInManager;
      _userManager = userManager;

    }
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
      var user = await _userManager.FindByEmailAsync(loginDto.Email);

      if (user == null) return Unauthorized();

      var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

      if (result.Succeeded)
      {
        return CreateUserObject(user);
      }

      return Unauthorized();

    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
      var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
      return CreateUserObject(user);

    }

    private UserDto CreateUserObject(AppUser user)
    {
      return new UserDto
      {
        DisplayName = user.DisplayName,
        Email = user.Email,
        Token = _tokenService.CreateToken(user),
        Username = user.UserName
      };
    }

  }
}