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
using Application.BackgroundTasks.GeneSync;
using System;

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
          opt.UseNpgsql(config.GetConnectionString("PostConnection"));

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
                  .WithOrigins(
                    "http://localhost:3000",
                    "https://chef-auto.virt.snet.biobio.tamu.edu"
                    );
            });
        });

      /* Mediator */
      services.AddMediatR(typeof(List.Handler).Assembly);

      /* Auto Mapper */
      services.AddAutoMapper(typeof(MappingProfiles).Assembly);

      /* Add User Accessor from Indfrastructure */
      services.AddScoped<IUserAccessor, UserAccessor>();

      /* Add Background Service */
      services.AddHostedService<BackgroundWorker>();
      services.AddSingleton<IBackgroundQueue<BTask>, BackgroundQueue<BTask>>();

      /* Background Tasks */
      services.AddScoped<IGeneSync, GeneSync>();

      return services;
    }
  }
}