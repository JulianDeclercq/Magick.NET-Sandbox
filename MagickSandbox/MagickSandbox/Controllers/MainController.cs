using Microsoft.AspNetCore.Mvc;

namespace MagickSandbox.Controllers;

[Route("")]
public class MainController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return ":)";
    }
}
