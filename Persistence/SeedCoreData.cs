using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Persistence.YAMLDTOs;
using YamlDotNet.Serialization;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
    private string _appOrganismPath;
    private string _appStrainPath;


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
      _appOrganismPath = "/app/Data/Sample/appOrganisms.yaml";
      _appStrainPath = "/app/Data/Sample/appStrains.yaml";
      _targetPromotionQuestionPath = "/app/Data/Sample/targetPromotionQuestions.yaml";
    }

    // Helper
    public static string GenerateStrongPassword(int length)
    {
      const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
      const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      const string digitChars = "1234567890";
      const string specialChars = "!@#$%^&*()-_=+[{]}\\|;:'\",<.>/?";
      const string validChars = lowercaseChars + uppercaseChars + digitChars + specialChars;

      using (var rng = RandomNumberGenerator.Create())
      {
        var bytes = new byte[length];
        rng.GetBytes(bytes);
        var passwordChars = new List<char>();

        // Add at least one lowercase letter
        passwordChars.Add(lowercaseChars[bytes[0] % lowercaseChars.Length]);

        // Add at least one uppercase letter
        passwordChars.Add(uppercaseChars[bytes[1] % uppercaseChars.Length]);

        // Add at least one digit
        passwordChars.Add(digitChars[bytes[2] % digitChars.Length]);

        // Add at least one special character
        passwordChars.Add(specialChars[bytes[3] % specialChars.Length]);

        // Add remaining characters randomly from the validChars string
        for (int i = 4; i < length; i++)
        {
          passwordChars.Add(validChars[bytes[i] % validChars.Length]);
        }

        var password = new string(passwordChars.ToArray());
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

      /* Create Default Organisms */
      if (!_context.Organisms.Any())
      {
        if (File.Exists(_appOrganismPath))
        {
          await seedAppOrganisms(_appOrganismPath);
        }
      }

      /* Create Default Strains */
      if (!_context.Strains.Any())
      {
        if (File.Exists(_appStrainPath))
        {
          await seedAppStrains(_appStrainPath);
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
      Console.WriteLine("INIT : Seeding App Roles");
      string ymlFileContent = File.ReadAllText(path);
      var deserializer = new DeserializerBuilder()
      .Build();

      var appRolesYml = deserializer.Deserialize<YAMLListDTO<AppRole>>(ymlFileContent);

      foreach (var role in appRolesYml.Data)
      {
        Console.WriteLine("Seeding Role: ");
        Console.WriteLine(role.Name);
        await _roleManager.CreateAsync(role);
      }

    }

    private async Task seedAppUsers(string path)
    {
      Console.WriteLine("INIT : Seeding App Users");
      string ymlFileContent = File.ReadAllText(path);
      var deserializer = new DeserializerBuilder()
      .Build();

      var appUsersYml = deserializer.Deserialize<YAMLListDTO<AppUser>>(ymlFileContent);

      foreach (var user in appUsersYml.Data)
      {
        Console.WriteLine("Seeding User: ");
        Console.WriteLine(user.DisplayName);
        Console.WriteLine(user.UserName);
        Console.WriteLine(user.Email);

        // User sign in is only allowed via SSO. Set a random password that would never be used.
        await _userManager.CreateAsync(user, GenerateStrongPassword(24));
      }

    }

    private async Task seedAdmins(string path)
    {
      Console.WriteLine("INIT : Seeding App Admins");
      string ymlFileContent = File.ReadAllText(path);
      var deserializer = new DeserializerBuilder()
      .Build();

      var adminsYml = deserializer.Deserialize<YAMLListDTO<string>>(ymlFileContent);

      foreach (var _admin in adminsYml.Data)
      {
        Console.WriteLine("Admin: ");
        Console.WriteLine(_admin);

        var _user = await _userManager.FindByEmailAsync(_admin);
        Console.WriteLine("User: ");
        Console.WriteLine(_user.ToString());

        var _roles = await _userManager.GetRolesAsync(_user);
        Console.WriteLine("Roles: ");
        Console.WriteLine(_roles.ToString());

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

    private async Task seedAppOrganisms(string path)
    {
      string ymlFileContent = File.ReadAllText(path);
      var deserializer = new DeserializerBuilder()
      .Build();

      var appOrganismYml = deserializer.Deserialize<YAMLListDTO<Organism>>(ymlFileContent);
      await _context.Organisms.AddRangeAsync(appOrganismYml.Data);

    }

    private async Task seedAppStrains(string path)
    { 
      Console.WriteLine("INIT : Seeding App Strains");
      string ymlFileContent = File.ReadAllText(path);
      var deserializer = new DeserializerBuilder()
      .Build();

      var appStrainYml = deserializer.Deserialize<YAMLListDTO<YAMLStrainDTO>>(ymlFileContent);

      foreach (var strain in appStrainYml.Data)
      {
        Console.WriteLine("Strain: ");
        Console.WriteLine(strain.Name);
        var _organism = await _context.Organisms.FirstOrDefaultAsync(o => o.CanonicalName == strain.OrganismCanonicalName);
        Console.WriteLine("Organism: ");
        Console.WriteLine(_organism.Name);

        if (_organism != null)
        {
          var _strainToAdd = new Strain()
          {
            Name = strain.Name,
            CanonicalName = strain.CanonicalName,
            OrganismId = _organism.Id,
          };
          await _context.Strains.AddAsync(_strainToAdd);
        }
      }
    }
  }
}