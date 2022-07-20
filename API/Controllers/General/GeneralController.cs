using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.General
{
  public class GeneralController : ApiControllerBase
  {

    [HttpGet("app-vars")]
    public async Task<IActionResult> GetAppVariables()
    {
      return HandleResult(await Mediator.Send(new Application.General.AppValues.Generate.Query { }));
    }
  }

}