namespace webapi.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class HelloWordController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    IHelloWordService helloWordService;
    TasksContext tasksContext;

    public HelloWordController(IHelloWordService helloWordService,
                               ILogger<WeatherForecastController> logger,
                               TasksContext tasksContext)
    {
        _logger = logger;
        this.helloWordService = helloWordService;
        this.tasksContext = tasksContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var helloWord = helloWordService.GetHelloWord();
        _logger.LogInformation($"Return: {helloWord}");
        return Ok(helloWordService.GetHelloWord());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDataBase()
    {
        tasksContext.Database.EnsureCreated();
        return Ok();
    }
}
