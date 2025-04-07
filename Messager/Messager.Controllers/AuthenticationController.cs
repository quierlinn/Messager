using Messager.Data;
using Messager.Messager.Services;
using Messager.Messager.Services.Abstractions;
using Messager.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthenticationController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        await _userService.RegisterUserAsync(user);
        return Ok();
    }
}