namespace webapi.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class HelloWordController : ControllerBase
{
    IHelloWordService helloWordService;

    public HelloWordController(IHelloWordService helloWordService)
    {
        this.helloWordService = helloWordService;
    }

    public IActionResult Get()
    {
        return Ok(helloWordService.GetHelloWord());
    }
}
