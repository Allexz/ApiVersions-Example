using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers;

[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class VersaodoisController : ControllerBase
{
    
    [HttpGet]
    [MapToApiVersion("2.0")]
    public IActionResult Get() => Ok("Hello from API Version 2.0");

    [HttpGet, Route("teste")]
    [MapToApiVersion("1.0")]
    public IActionResult GetV2() => Ok("Hello from API Version 2.0");
}
