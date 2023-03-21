using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Persistence.YAMLDTOs;
using YamlDotNet.Serialization;
using System.Security.Cryptography;

namespace Persistence
{
  public class SeedCoreData
  {
    private DataContext _context;
    private UserManager<AppUser> _userManager;
    private RoleManager<AppRole> _roleManager;

    private string _appRolePath;
    private string _appUserPath;
    private string _appAdminPath;
    private string _appValPath;
    private string _targetPromotionQuestionPath;


    public SeedCoreData(DataContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
      _context = context;
      _userManager = userManager;
      _roleManager = roleManager;

      _appRolePath = "/app/Data/Sample/appRoles.yaml";
      _appUserPath = "/app/Data/Sample/appUsers.yaml";
      _appAdminPath = "/app/Data/Sample/appAdmins.yaml";
      _appValPath = "/app/Data/Sample/appVals.yaml";
      _targetPromotionQuestionPath = "/app/Data/Sample/targetPromotionQuestions.yaml";
    }

    // Helper
    public static string GenerateStrongPassword(int length)
    {
      const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()-_=+[{]}\\|;:'\",<.>/?";
      using (var rng = RandomNumberGenerator.Create())
      {
        var bytes = new byte[length];
        rng.GetBytes(bytes);
        var password = new string(bytes
            .Select(b => validChars[b % validChars.Length])
            .ToArray());
        return password;
      }
    }

    public async Task SeedCore()
    {
      /* Create Default Roles */
      if (!_roleManager.Roles.Any())
      {
        if (File.Exists(_appRolePath))
          await seedAppRoles(_appRolePath);
      }


      /* Create Default Users */
      if (!_userManager.Users.Any())
      {
        if (File.Exists(_appUserPath))
          await seedAppUsers(_appUserPath);
      }

      /* Create Default Admins */
      if (File.Exists(_appAdminPath))
      {
        await seedAdmins(_appAdminPath);
      }


      /* Create Basic App Data */
      if (!_context.Questions.Any())
      {
        if (File.Exists(_targetPromotionQuestionPath))
        { await seedTargetPromotionQuestions(_targetPromotionQuestionPath); }
      }


      /* Create Default AppVals */
      if (!_context.AppVals.Any())
      {
        if (File.Exists(_appValPath))
        {
          await seedAppVals(_appValPath);
        }
      }

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
        // User sign in is only allowed via SSO. Set a random password that would never be used.
        await _userManager.CreateAsync(user, GenerateStrongPassword(24));
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

    private async Task seedAppVals(string path)
    {
      string ymlFileContent = File.ReadAllText(path);
      var deserializer = new DeserializerBuilder()
      .Build();

      var appValueYml = deserializer.Deserialize<YAMLListDTO<AppVals>>(ymlFileContent);
      await _context.AppVals.AddRangeAsync(appValueYml.Data);

    }

  }
}