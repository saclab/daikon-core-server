using Application.Core;
using Application.Genomes;
using Application.Interfaces;
using Infrastructure.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace API.Extensions
{
  public static class ApplicationServiceExtensions
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
      /* Add DB */
      services.AddDbContext<DataContext>(opt =>
        {
          opt.UseSqlite(config.GetConnectionString("SQLiteConnection"));
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
                    "https://chef-auto.virt.snet.biobio.tamu.edu:3000"
                    );
            });
        });

      /* Mediator */
      services.AddMediatR(typeof(List.Handler).Assembly);

      /* Auto Mapper */
      services.AddAutoMapper(typeof(MappingProfiles).Assembly);

      /* Add User Accessor from Indfrastructure */
      services.AddScoped<IUserAccessor, UserAccessor>();

      return services;
    }
  }
}