using Domain;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
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

    public virtual async Task<int> SaveChangesAsync(string userId = null)
    {
      TrackChanges(userId);
      var result = await base.SaveChangesAsync();
      return result;
    }


    private void TrackChanges(string userId)
    {
      ChangeTracker.DetectChanges();

      var changed = ChangeTracker.Entries().ToList();

      foreach (var entry in changed)
      {
        if (entry.Entity is ChangeLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
          continue;

        // extract primary key
        var primaryKey = "";
        foreach (var propertyLookPrimary in entry.Properties)
        {
          if (propertyLookPrimary.Metadata.IsPrimaryKey())
          {
            primaryKey = propertyLookPrimary.CurrentValue.ToString();
            continue;
          }
        }

        foreach (var property in entry.Properties)
        {
          var changeLog = new ChangeLog();
          changeLog.PrimaryKeyValue = primaryKey;
          changeLog.EntityName = entry.Entity.GetType().Name;
          changeLog.DateChanged = DateTime.UtcNow;
          changeLog.ModifiedBy = userId;

          // check if it is a primary key
          string propertyName = property.Metadata.Name;


          changeLog.PropertyName = propertyName;

          switch (entry.State)
          {
            case EntityState.Added:
              changeLog.OldValue = null;
              changeLog.NewValue = JsonSerializer.Serialize(property.CurrentValue);
              changeLog.Type = ChangeType.Create.ToString();
              ChangeLogs.Add(changeLog);
              break;

            case EntityState.Deleted:
              changeLog.OldValue = JsonSerializer.Serialize(property.CurrentValue);
              changeLog.NewValue = null;
              changeLog.Type = ChangeType.Delete.ToString();
              ChangeLogs.Add(changeLog);
              break;

            case EntityState.Modified:
              if (property.IsModified)
              {
                changeLog.OldValue = JsonSerializer.Serialize(property.OriginalValue);
                changeLog.NewValue = JsonSerializer.Serialize(property.CurrentValue);
                changeLog.Type = ChangeType.Update.ToString();
                ChangeLogs.Add(changeLog);
              }
              break;
          }

        }

      }
    }



    public DbSet<Gene> Genes { get; set; }
    public DbSet<ChangeLog> ChangeLogs { get; set; }
    public DbSet<GenePublicData> GenePublicData { get; set; }
    public DbSet<GeneNonPublicData> GeneNonPublicData { get; set; }

  }
}