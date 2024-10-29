using System.Net;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomBaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(ServiceResult<T> result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.NoContent => NoContent(),
            HttpStatusCode.Created => Created(result.UrlAsCreated, result.Data),
            _ => new ObjectResult(result) { StatusCode = result.StatusCode.GetHashCode() }
        };
    }

    [NonAction]
    public IActionResult CreateActionResult(ServiceResult result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.NoContent => NoContent(),
            _ => new ObjectResult(result) { StatusCode = result.StatusCode.GetHashCode() }
        };
     }
}