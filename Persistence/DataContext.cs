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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

        //  modelBuilder.Entity<Gene>()
        //     .HasOne<GenePublicData>(g => g.GenePublicData)
        //     .WithOne(gpd => gpd.Gene)
        //     .HasForeignKey<GenePublicData>(gpd => gpd.RefGeneID);
    }
    



    public DbSet<Gene> Genes { get; set; }
    public DbSet<GenePublicData> GenePublicData { get; set; }
    public DbSet<GeneNonPublicData> GeneNonPublicData { get; set; }
  }
}