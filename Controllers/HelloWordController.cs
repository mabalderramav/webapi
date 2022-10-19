namespace webapi.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class HelloWordController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    IHelloWordService helloWordService;

    public HelloWordController(IHelloWordService helloWordService, ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        this.helloWordService = helloWordService;
    }

    public IActionResult Get()
    {
        var helloWord = helloWordService.GetHelloWord();
        _logger.LogInformation($"Return: {helloWord}");
        return Ok(helloWordService.GetHelloWord());
    }
}
