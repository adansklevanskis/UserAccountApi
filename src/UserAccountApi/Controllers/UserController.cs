using Microsoft.AspNetCore.Mvc;
using UserAccountApi.Domain.Services;

namespace WebApplication1.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet]
    public Task<string> GetUserAsync(string username)
    {
        _logger.LogInformation("Getting user from GetUserWelcomeMessageAsync");
        var response = _userService.GetUserWelcomeMessageAsync(username);
        _logger.LogInformation("User message {reponse}", response);
        return response;  
    }
}
