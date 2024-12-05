using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers;
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ProdutoComercialController : ControllerBase
{
    [MapToApiVersion("1.0")]
    [HttpGet]
    public IActionResult Getv1() => Ok("Recuperou Produto Comercial da versão 1");

    [MapToApiVersion("2.0")]
    [HttpGet, Route("novo")]
    public IActionResult Getv2() => Ok("Recuperou Produto Comercial da versão 2");
}
