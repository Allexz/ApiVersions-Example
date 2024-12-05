using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers;
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class FornecedorController : ControllerBase
{
    [HttpGet, Route("novo")]
    [MapToApiVersion("2.0")]
    public IActionResult GetV1() => Ok("Recuperou o Fornecedor da versão 2");

    [HttpGet]
    [MapToApiVersion("1.0")]
    public IActionResult GetV2() => Ok("Recuperou o Fornecedor da versão 1");
}
