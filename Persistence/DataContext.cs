using Domain;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using Domain.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Domain.Models;
using Domain.AppConfigurations;
using Domain.AppBackgroundTasks;

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

      /* Making Key column unique in AppConfiguration */
      modelBuilder.Entity<AppConfiguration>()
        .HasIndex(p => p.Key)
        .IsUnique();




      /* Questions Entity. handle PossibleAnswers Field to have multiple value */


      var StringArrayToStringConverter = new ValueConverter<string[], string>(
                v => string.Join(";", v),
                v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => val).ToArray());


      modelBuilder.Entity<Question>()
      .Property(e => e.PossibleAnswers)
                .HasConversion(StringArrayToStringConverter);

      modelBuilder.Entity<Discussion>()
      .Property(e => e.Mentions)
                .HasConversion(StringArrayToStringConverter);
      modelBuilder.Entity<Discussion>()
      .Property(e => e.Tags)
                .HasConversion(StringArrayToStringConverter);
      modelBuilder.Entity<Reply>()
      .Property(e => e.Mentions)
                .HasConversion(StringArrayToStringConverter);
      modelBuilder.Entity<Reply>()
      .Property(e => e.Tags)
        .HasConversion(StringArrayToStringConverter);

    }

    public virtual async Task<int> SaveChangesAsync(string userId)
    {
      userId = userId ?? "System";
      isModifyingAllowed();
      TrackChanges(userId);
      updateEntityTimeStamp(userId);
      var result = await base.SaveChangesAsync();
      return result;
    }

    private void isModifyingAllowed()
    {
      var entities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted)
            .Select(e => e.Entity);

      // Check if any of the entities have isReadOnly set to true
      bool anyReadOnly = entities.Any(e => e.GetType().GetProperty("IsReadOnly") != null && (bool)e.GetType().GetProperty("IsReadOnly").GetValue(e));

      if (anyReadOnly)
      {
        // Throw an exception or log an error, since we cannot save changes when isReadOnly is true
        throw new InvalidOperationException("Cannot save changes when property is Read Only.");
      }

      bool anyIsLocked = entities.Any(e => e.GetType().GetProperty("IsLocked") != null && (bool)e.GetType().GetProperty("IsLocked").GetValue(e));
      if (anyIsLocked)
      {
        throw new InvalidOperationException("Cannot save changes when property is Locked.");
      }

    }

    private void updateEntityTimeStamp(string userId)
    {
      userId = userId ?? "System";

      // For new Entries
      var entities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified)
            .Select(e => e.Entity);

      foreach (var entity in entities)
      {
        var lastEditAtColumn = entity.GetType().GetProperty("LastEditAt");
        if (lastEditAtColumn != null)
        {
          lastEditAtColumn.SetValue(entity, DateTime.UtcNow);
        }

        var lastEditByColumn = entity.GetType().GetProperty("LastEditBy");
        if (lastEditByColumn != null)
        {
          var user = userId ?? "System";
          lastEditByColumn.SetValue(entity, user);
        }
      }

      // For Existing Entries
      var entities2 = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added)
            .Select(e => e.Entity);
      foreach (var entity in entities2)
      {
        var createdAtColumn = entity.GetType().GetProperty("CreatedAt");
        if (createdAtColumn != null)
        {
          createdAtColumn.SetValue(entity, DateTime.UtcNow);
        }

        var createdByColumn = entity.GetType().GetProperty("CreatedBy");
        if (createdByColumn != null)
        {
          var user = userId ?? "System";
          createdByColumn.SetValue(entity, user);
        }
      }
    }

    private void TrackChanges(string userId)
    {
      userId = userId ?? "System";
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
              //changeLog.NewValue = JsonSerializer.Serialize(property.CurrentValue);
              changeLog.NewValue = property.CurrentValue != null ? property.CurrentValue.ToString() : null;
              changeLog.Type = ChangeType.Create.ToString();
              ChangeLogs.Add(changeLog);
              break;

            case EntityState.Deleted:
              //changeLog.OldValue = JsonSerializer.Serialize(property.CurrentValue);
              changeLog.OldValue = property.OriginalValue != null ? property.OriginalValue.ToString() : null;
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

                changeLog.OldValue = property.OriginalValue != null ? property.OriginalValue.ToString() : null;
                changeLog.NewValue = property.CurrentValue != null ? property.CurrentValue.ToString() : null;
                changeLog.Type = ChangeType.Update.ToString();
                ChangeLogs.Add(changeLog);
              }
              break;
          }

        }

      }
    }


    /* App Core */
    public DbSet<ChangeLog> ChangeLogs { get; set; }
    public DbSet<BTask> BTask { get; set; }
    public DbSet<AppOrg> AppOrgs { get; set; }

    public DbSet<AppConfiguration> AppConfigurations { get; set; }
    public DbSet<AppBackgroundTaskLog> AppBackgroundTasksLog { get; set; }

    /* Business Core */
    public DbSet<Question> Questions { get; set; }
    public DbSet<AppVals> AppVals { get; set; }

    /* Strain */
    public DbSet<Organism> Organisms { get; set; }
    public DbSet<Strain> Strains { get; set; }

    /* Gene */
    public DbSet<Gene> Genes { get; set; }
    public DbSet<GeneExternalId> GeneExternalIds { get; set; }
    public DbSet<GenePublicData> GenePublicData { get; set; }
    // public DbSet<GeneNonPublicData> GeneNonPublicData { get; set; }
    public DbSet<GeneVulnerability> GeneVulnerability { get; set; }
    public DbSet<GeneEssentiality> GeneEssentiality { get; set; }
    public DbSet<GeneProteinProduction> GeneProteinProductions { get; set; }
    public DbSet<GeneProteinActivityAssay> GeneProteinActivityAssays { get; set; }
    public DbSet<GeneCRISPRiStrain> GeneCRISPRiStrains { get; set; }
    public DbSet<GeneResistanceMutation> GeneResistanceMutations { get; set; }
    public DbSet<GeneUnpublishedStructures> GeneUnpublishedStructures { get; set; }
    public DbSet<GenePromotionRequest> GenePromotionRequests { get; set; }
    public DbSet<GenePromtionRequestGene> GenePromtionRequestGenes { get; set; }
    public DbSet<GenePromotionRequestValue> GenePromotionRequestValues { get; set; }
    public DbSet<GeneHypomorph> GeneHypomorphs { get; set; }


    /* Target */
    public DbSet<Target> Targets { get; set; }
    public DbSet<TargetGene> TargetGenes { get; set; }
    public DbSet<TargetScorecard> TargetScorecards { get; set; }
    public DbSet<TargetScoreCardValue> TargetScoreCardValues { get; set; }

    /* Screen */
    public DbSet<Screen> Screens { get; set; }
    public DbSet<ScreenSequence> ScreenSequences { get; set; }
    public DbSet<Hit> Hits { get; set; }

    /* Discussion */
    public DbSet<Discussion> Discussions { get; set; }
    public DbSet<Reply> Replies { get; set; }

    /* Compound */
    public DbSet<Compound> Compounds { get; set; }

    /* Project */
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectBaseHits> ProjectBaseHits { get; set; }
    public DbSet<ProjectSupportingOrg> ProjectSupportingOrgs { get; set; }
    public DbSet<ProjectParticipatingOrg> ProjectParticipatingOrgs { get; set; }

    //ProjectCompoundEvolution
    public DbSet<ProjectCompoundEvolution> ProjectCompoundEvolutions { get; set; }

    public DbSet<GeneGroup> GeneGroups { get; set; }
    public DbSet<GeneGroupGenes> GeneGroupGenes { get; set; }


    //Vote
    public DbSet<Vote> Votes { get; set; }
    public DbSet<Voter> Voters { get; set; }

  }
}