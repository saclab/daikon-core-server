using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public class DataContext : IdentityDbContext<AppUser, AppRole, string>
  {
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Gene> Genes { get; set; }
    
  }
}