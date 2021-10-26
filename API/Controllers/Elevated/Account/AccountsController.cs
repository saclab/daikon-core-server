using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using Persistence;
using Microsoft.EntityFrameworkCore;
using API.DTOs;

namespace API.Controllers.Elevated
{
  [ApiController]


  public class AccountsController : BaseApiController
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly DataContext _context;
    public AccountsController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, DataContext context)
    {
      _userManager = userManager;
      _roleManager = roleManager;
      _context = context;

    }

    [HttpGet("roles")]
    public async Task<ActionResult<List<AppRole>>> GetRoles()
    {

      var roles = _roleManager.Roles.ToList();
      return roles;

    }

    [HttpGet("orgs")]
    public async Task<ActionResult<List<AppOrg>>> GetOrgs()
    {
      var orgs = await _context.AppOrgs.ToListAsync();
      return orgs;
    }

    [HttpPost("orgs")]
    public async Task<ActionResult> addOrg(AppOrg newAppOrg)
    {
      var existsName = await _context.AppOrgs.FirstOrDefaultAsync(a => a.Name == newAppOrg.Name);
      if (existsName != null)
      {
        return BadRequest("Organization Name already exists");
      }
      var existsAlias = await _context.AppOrgs.FirstOrDefaultAsync(a => a.Alias == newAppOrg.Alias);
      if (existsAlias != null)
      {
        return BadRequest("Organization Alias already exists");
      }

      Guid gid = Guid.NewGuid();
      var appOrgToCreate = new AppOrg
      {
        Id = gid,
        Name = newAppOrg.Name,
        Alias = newAppOrg.Alias,
        Address = newAppOrg.Address
      };

      _context.AppOrgs.Add(appOrgToCreate);


      var success = await _context.SaveChangesAsync() > 0;

      if (!success) return UnprocessableEntity("Failed to add new org");
      return Ok();
    }

    [HttpPost("roles")]
    public async Task<ActionResult> addRole(AppRole newAppRole)
    {
      var existsRole = await _roleManager.FindByNameAsync(newAppRole.Name);
      if (existsRole != null)
      {
        return BadRequest("Role Name already exists");
      }

      Guid gid = Guid.NewGuid();
      var appRoleToCreate = new AppRole
      {
        Name = newAppRole.Name,
        Description = newAppRole.Description
      };

      var success = await _roleManager.CreateAsync(newAppRole);

      if (!success.Succeeded) return UnprocessableEntity("Failed to add new org");
      return Ok();
    }



    [HttpGet]
    public async Task<ActionResult> listUsers()
    {

      var users = _userManager.Users;
      var formattedUsers = new List<API.DTOs.UserDto> { };
      foreach (var user in users)
      {
        //var roles = await _userManager.GetRolesAsync(user);
        formattedUsers.Add(CreateUserObject(user, new List<String>()));
      }
      return Ok(formattedUsers);
    }

    [HttpGet("{email}")]
    public async Task<ActionResult<RegisterDto>> userDetails(string email)
    {

      var user = await _context.Users
      .Include(u => u.Org)
      .FirstOrDefaultAsync(u => u.Email == email);
      var roles = await _userManager.GetRolesAsync(user);

      var formattedUser =  new RegisterDto {
        Email = user.Email,
        DisplayName = user.DisplayName,
        OrgId = user.Org != null?user.Org.Id:Guid.Empty,
        Bio = user.Bio,
        Roles = roles,
        Lock = user.Lock
      };

      
      return formattedUser;
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

      var userOrg = await _context.AppOrgs.FirstOrDefaultAsync(a => a.Id == newUser.OrgId);
      if (userOrg == null)
      {
        return BadRequest("Bad org id");
      }

      // add the user

      var user = new AppUser
      {
        DisplayName = newUser.DisplayName,
        Email = newUser.Email,
        UserName = newUser.Email,
        Org = userOrg
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

    [HttpPost("{email}")]
    public async Task<ActionResult> updateUser(string email, RegisterDto updatedUser)
    {
      var user = await _userManager.FindByEmailAsync(email);
      if(user == null){
        return BadRequest("Cannot Find User");
      }
      
      if (updatedUser.OrgId == null)
      {
        return BadRequest("User must belong to an Organization");
      }

      var userOrg = await _context.AppOrgs.FirstOrDefaultAsync(o => o.Id == updatedUser.OrgId);
      if(userOrg == null){
        return BadRequest("Invalid Org ID");
      }
      user.DisplayName = updatedUser.DisplayName;
      user.Bio = updatedUser.Bio;
      user.Lock = updatedUser.Lock;
      user.Org = userOrg;
      
      var roles = await _userManager.GetRolesAsync(user);

     

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