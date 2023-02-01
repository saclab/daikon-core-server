using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
  public interface IUserAccessor
  {
    string GetUsername();
    Task<Guid> GetUserOrgId();
    Task<bool> isInRole(string roleName);
  }
}