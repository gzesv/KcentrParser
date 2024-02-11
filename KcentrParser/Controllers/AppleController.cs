using KcentrParser.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KcentrParser.Controllers;

[ApiController]
[Route("[controller]")]
public class AppleController : ControllerBase
{
    private readonly IAppleService _appleService;

    public AppleController(IAppleService appleService)
    {
        _appleService = appleService;
    }

    [HttpGet]
    [Route("")]
    public ActionResult GetAllApples()
    {
        var apples = _appleService.GetAllApples();

        return Content(JsonConvert.SerializeObject(apples), "application/json");
    }
}