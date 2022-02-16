using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CustomResponses.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class MainController : ControllerBase
  {
    protected ActionResult CustomResponse(int statusCode = 200, object result = null, object errros = null)
    {

      switch (statusCode)
      {
        case 201:
          return StatusCode(201, new
          {
            success = true,
            data = result
          });
        case 204:
          return NoContent();
        case 400:
        case 404:
        case 500:
          return BadRequest(new
          {
            success = false,
            errors = errros
          });
        default:
          return Ok(new
          {
            success = true,
            data = result
          });
      }
    }
  }
}
