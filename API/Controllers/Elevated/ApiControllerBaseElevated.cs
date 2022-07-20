using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers.Elevated
{
  [ApiController]
  [Route("api/elevated/[controller]")]
  [Authorize(Policy = "RequireAdministratorRole")]
  public class ApiControllerBaseElevated : ControllerBase
  {
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    protected ActionResult HandleResult<T>(Result<T> result)
    {
      if (result == null) return NotFound();
      if (result.IsSuccess && result.Value != null) return Ok(result.Value);
      if (result.IsSuccess && result.Value == null) return NotFound();
      return BadRequest(result.Error);
    }
  }
}