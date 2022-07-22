using System;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.Middleware
{
  public class APIRequestLogsMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly ILogger<APIRequestLogsMiddleware> _logger;
    private readonly IHostEnvironment _env;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private string _username;
    public APIRequestLogsMiddleware(RequestDelegate next, ILogger<APIRequestLogsMiddleware> logger, IHostEnvironment env, IHttpContextAccessor httpContextAccessor)
    {
      _env = env;
      _logger = logger;
      _next = next;
      _httpContextAccessor = httpContextAccessor;

    }

    public async Task InvokeAsync(HttpContext context)
    {

      var username = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
      var endpoint = context.GetEndpoint();
      DateTime now = DateTime.Now;
      if (endpoint != null)
      {
        var controllerActionDescriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
        if (controllerActionDescriptor != null)
        {
          var controllerName = controllerActionDescriptor.ControllerName;
          _logger.LogInformation($"APIAccessLog | {now.ToString()} | {context.Connection.RemoteIpAddress} | {context.Request.Path} | {controllerName} | {username}");
        }
      }


      await _next(context);
    }
  }
}