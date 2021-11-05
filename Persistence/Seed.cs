using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;



namespace Persistence
{
  public class Seed
  {
    public static async Task SeedData(DataContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {

      /* Seed core data that is absolutely required */
      SeedCoreData seedCoreData = new SeedCoreData(context, userManager, roleManager);
      await seedCoreData.SeedCore();

      /* CAUTION /!\ 
          Data in the SeedTestData class below are public and are commited to source control.
          Do **NOT** put any sensitive information in this file.
          The intention of the below data is strictly for testing purposes only 
          and will be removed on production builds.
      */
      //  SeedTestData seedTestData = new SeedTestData(context);
      //  await seedTestData.SeedTest();
    }
  }
}

