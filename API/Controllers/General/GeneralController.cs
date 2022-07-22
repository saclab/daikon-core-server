using System.Security.Claims;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers.General
{
  public class GeneralController : ApiControllerBase
  {
    private readonly ILogger<ApiControllerBase> _logger;
    


    [HttpGet("app-vars")]
    public async Task<IActionResult> GetAppVariables()
    {
      return HandleResult(await Mediator.Send(new Application.General.AppValues.Generate.Query { }));
    }
  }

}