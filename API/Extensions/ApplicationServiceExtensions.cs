using Application.Core;
using Application.Interfaces;
using Infrastructure.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Application.Genes;
using Domain.Tasks;
using System;
using Application.BackgroundServices;
using Application.BackgroundTasks.Genes;
using Domain.AppBackgroundTasks;

namespace API.Extensions
{
  public static class ApplicationServiceExtensions
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {

      /* Add DB */
      services.AddDbContext<DataContext>(opt =>
        {

          //opt.UseSqlite(config.GetConnectionString("SQLiteConnection"));
          var buildConnectionString = "Username=" + Environment.GetEnvironmentVariable("PGUSER") + ";"
          + "Password=" + Environment.GetEnvironmentVariable("PGPASSWORD") + ";"
          + Environment.GetEnvironmentVariable("PGSQL_CONNECTION_STRING");
          opt.UseNpgsql(buildConnectionString);
        });

      /* Add CORS */



      services.AddCors(opt =>
      {
        opt.AddPolicy("CorsPolicy", policy =>
          {
            policy
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials()
                  .WithExposedHeaders("WWW-Authenticate", "Pagination")
                  .WithOrigins(Environment.GetEnvironmentVariable("CORS_ORIGINS"));
          });
      });

      /* Mediator */
      services.AddMediatR(typeof(List.Handler).Assembly);
      services.AddMediatR(typeof(DataView.TargetDash.Handler).Assembly);

      /* Auto Mapper */
      services.AddAutoMapper(typeof(MappingProfiles).Assembly);

      /* Add User Accessor from Indfrastructure */
      services.AddScoped<IUserAccessor, UserAccessor>();

      /* Add Background Services */
      // Gene Pool Sync Services
      services.AddHostedService<GenePoolBackgroundWorker>();
      services.AddSingleton<IBackgroundQueue<GenePoolBackgroundTask>, BackgroundQueue<GenePoolBackgroundTask>>();

      /* Background Tasks */
      services.AddScoped<IGeneSynchronizer, GeneSynchronizer>();

      return services;
    }
  }
}