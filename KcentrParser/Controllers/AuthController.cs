using KcentrParser.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KcentrParser.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    [Route("{login}")]
    public ActionResult GetToken(string login)
    {
        string token = _authService.GetToken(login);

        return Content(JsonConvert.SerializeObject(token), "application/json");
    }
}