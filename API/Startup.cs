using API.Extensions;
using API.Middleware;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Application.Genes;
using System.Collections.Generic;

namespace API
{
  public class Startup
  {
    private readonly IConfiguration _config;
    public Startup(IConfiguration config)
    {
      _config = config;
    }



    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddControllers(opt =>
      {
        var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        opt.Filters.Add(new AuthorizeFilter(policy));
      })

      .AddFluentValidation(config =>
     {
       config.RegisterValidatorsFromAssemblyContaining<Create>();
     });

      // Register the Swagger generator, defining 1 or more Swagger documents
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });


        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                  Enter 'Bearer' [space] and then your token in the text input below.
                  \r\n\r\nExample: 'Bearer 12345abcdef'",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
            {
              new OpenApiSecurityScheme
              {
                    Reference = new OpenApiReference
                      {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                      },
                      Scheme = "oauth2",
                      Name = "Bearer",
                      In = ParameterLocation.Header,

                    },
                    new List<string>()
                  }
      });
        //        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        //c.IncludeXmlComments(xmlPath);
      });

      services.AddApplicationServices(_config);
      services.AddIdentityServices(_config);

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

      app.UseMiddleware<ExceptionMiddleware>();

      if (env.IsDevelopment())
      {
        //app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
      }

      /* Not using https in dev*/
      //app.UseHttpsRedirection();

      app.UseRouting();


      app.UseCors("CorsPolicy");

      app.UseAuthentication();

      app.UseAuthorization();

      app.UseMiddleware<APIRequestLogsMiddleware>();



      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
