using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Security
{
  public class UserAccessor : IUserAccessor
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly DataContext _context;
    public UserAccessor(IHttpContextAccessor httpContextAccessor, DataContext context)
    {
      _httpContextAccessor = httpContextAccessor;
      _context = context;
    }
    public string GetUsername()
    {
      return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
    }

    public async Task<Guid> GetUserOrgId()
    {
      Console.WriteLine("Trace");
      Console.WriteLine(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name));
      Console.WriteLine(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email));

      var user = await _context.Users
        .Include(u => u.Org)
        .FirstOrDefaultAsync(u => u.Email == _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email));
      return user.Org.Id;
    }

    public async Task<bool> isInRole(string roleName)
    {
      var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
      var roleId = role.Id;

      var user = await _context.Users
       .Include(u => u.Org)
       .FirstOrDefaultAsync(u => u.Email == _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email));

      var roles = await _context.UserRoles.Where((u) => u.UserId == user.Id).Select(r => r.RoleId).ToListAsync();
      return roles.Contains(roleId);
    }
  }
}