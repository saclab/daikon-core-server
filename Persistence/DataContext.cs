using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public class DataContext : IdentityDbContext<AppUser>
  {
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Genome> Genomes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      /* gives AppUSer a primary key of string */
      base.OnModelCreating(builder);

      
    }


  }
}
