using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace API.Controllers.General
{
  [ApiController]
  [Authorize(Policy = "RequireUserRole")]
  [Route("api/[controller]")]
  public class ApiControllerBase : ControllerBase
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