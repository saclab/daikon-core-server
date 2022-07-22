using System;
using API.Controllers.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers.Test
{
  public class BuggyController : General.ApiControllerBase
  {

    [HttpGet("not-found")]
    public ActionResult GetNotFound()
    {
      return NotFound();
    }

    [HttpGet("bad-request")]
    public ActionResult GetBadRequest()
    {
      return BadRequest("This is a bad request");
    }

    [HttpGet("server-error")]
    public ActionResult GetServerError()
    {
      throw new Exception("This is a server error");
    }

    [HttpGet("unauthorised")]
    public ActionResult GetUnauthorised()
    {
      return Unauthorized();
    }
  }
}