using Domain;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using Domain.Tasks;
using Domain.Question;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

      /* Questions Entity. handle PossibleAnswers Field to have multiple value */
      var QuestionPossibleAnswersconverter = new ValueConverter<string[], string>(
                v => string.Join(";", v),
                v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => val).ToArray());

      modelBuilder.Entity<Question>()
      .Property(e => e.PossibleAnswers)
                .HasConversion(QuestionPossibleAnswersconverter);
    }

    public virtual async Task<int> SaveChangesAsync(string userId = null)
    {
      TrackChanges(userId);
      var result = await base.SaveChangesAsync();
      return result;
    }


    private void TrackChanges(string userId = null)
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
              /* Dont need to serialize as we can use ToString, serializing adds and extra quote to data */
              changeLog.OldValue = null;
              changeLog.NewValue = JsonSerializer.Serialize(property.CurrentValue);
              //changeLog.NewValue = property.CurrentValue.ToString();
              changeLog.Type = ChangeType.Create.ToString();
              ChangeLogs.Add(changeLog);
              break;

            case EntityState.Deleted:
              //changeLog.OldValue = JsonSerializer.Serialize(property.CurrentValue);
              changeLog.OldValue = property.OriginalValue.ToString();
              changeLog.NewValue = null;
              changeLog.Type = ChangeType.Delete.ToString();
              ChangeLogs.Add(changeLog);
              break;

            case EntityState.Modified:
              if (property.IsModified)
              {
                /* Dont need to serialize as we can use ToString */
                // changeLog.OldValue = JsonSerializer.Serialize(property.OriginalValue);
                // changeLog.NewValue = JsonSerializer.Serialize(property.CurrentValue);

                changeLog.OldValue = property.OriginalValue.ToString();
                changeLog.NewValue = property.CurrentValue.ToString();
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
    public DbSet<BTask> BTask { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<GenePromotionQuestionaireAnswer> GenePromotionQuestionaireAnswers { get; set; }

  }
}