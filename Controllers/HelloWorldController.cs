using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{

    TareasContext dbcontext;
    IHelloWorldService helloWorldService;
    private readonly ILogger<HelloWorldController> _logger;
    public HelloWorldController(ILogger<HelloWorldController> logger, IHelloWorldService helloWorld, TareasContext db)
    {
        _logger = logger;
        helloWorldService = helloWorld;
        dbcontext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("eso era todo");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDB()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}