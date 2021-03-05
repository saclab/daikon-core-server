using Microsoft.AspNetCore.Authorization;

/*
Why are we using this?

We are authenticating against AD but are fetching roles from role manager.
The calims from .RequireRole() expects the role to be in the http claims
But we dont have as we are not maintaining roles in ad.
So we need to build a custom policy that would fetch the user email from token
then fetch user object from user manager by looking up the email
then see if it has the assigned role.

*/

namespace API.Policies
{
  public class RequireAppRole : IAuthorizationRequirement
  {
    public string RoleName { get; set; }
    public RequireAppRole(string roleName)
    {
      RoleName = roleName;
    }

  }
}