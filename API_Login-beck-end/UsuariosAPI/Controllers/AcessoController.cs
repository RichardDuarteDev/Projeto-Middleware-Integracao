using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("Acesso")]
public class AcessoController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Acesso OK");
    }

}
/*
[ApiController]
[Route("[Controller]")]
public class AcessoController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult Get()
    {
        return Ok("Acesso permitido");
    }

}
*/

