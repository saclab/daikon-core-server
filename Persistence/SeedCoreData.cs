using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Persistence.YAMLDTOs;
using YamlDotNet.Serialization;

namespace Persistence
{
  public class SeedCoreData
  {
    private DataContext _context;
    private UserManager<AppUser> _userManager;
    private RoleManager<AppRole> _roleManager;

    public SeedCoreData(DataContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
      _context = context;
      _userManager = userManager;
      _roleManager = roleManager;
    }
    public async Task SeedCore()
    {
      /* Create Default Roles */
      if (!_roleManager.Roles.Any())
        await seedAppRoles("/app/Data/Sample/appRoles.yaml");

      /* Create Default Users */
      if (!_userManager.Users.Any())
        await seedAppUsers("/app/Data/Sample/appUsers.yaml");

      /* Create Default Admins */
      await seedAdmins("/app/Data/Sample/appAdmins.yaml");

      /* Create Basic App Data */
      if (!_context.Questions.Any())
        await seedTargetPromotionQuestions("/app/Data/Sample/targetPromotionQuestions.yaml");


      await _context.SaveChangesAsync();

    }

    private async Task seedTargetPromotionQuestions(string path)
    {
      string ymlFileContent = File.ReadAllText(path);
      var deserializer = new DeserializerBuilder()
      .Build();

      var questionsYml = deserializer.Deserialize<YAMLListDTO<Question>>(ymlFileContent);
      await _context.Questions.AddRangeAsync(questionsYml.Data);
    }

    private async Task seedAppRoles(string path)
    {
      string ymlFileContent = File.ReadAllText(path);
      var deserializer = new DeserializerBuilder()
      .Build();

      var appRolesYml = deserializer.Deserialize<YAMLListDTO<AppRole>>(ymlFileContent);

      foreach (var role in appRolesYml.Data)
      {
        await _roleManager.CreateAsync(role);
      }

    }

    private async Task seedAppUsers(string path)
    {
      string ymlFileContent = File.ReadAllText(path);
      var deserializer = new DeserializerBuilder()
      .Build();

      var appUsersYml = deserializer.Deserialize<YAMLListDTO<AppUser>>(ymlFileContent);

      foreach (var user in appUsersYml.Data)
      {
        await _userManager.CreateAsync(user, "P@ssw0rdTh@TW!llNeverBeUsed=S!gnIn0nly@ll0wedV!@AD");
      }

    }

    private async Task seedAdmins(string path)
    {
      string ymlFileContent = File.ReadAllText(path);
      var deserializer = new DeserializerBuilder()
      .Build();

      var adminsYml = deserializer.Deserialize<YAMLListDTO<string>>(ymlFileContent);

      foreach (var _admin in adminsYml.Data)
      {
        var _user = await _userManager.FindByEmailAsync(_admin);
        var _roles = await _userManager.GetRolesAsync(_user);
        if (!_roles.Contains("admin"))
        {
          await _userManager.AddToRoleAsync(_user, "admin");
        }
      }

    }
  }
}