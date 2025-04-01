using Messager.Data;
using Messager.Messager.Services;
using Messager.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly UserService _userService;

    public AuthenticationController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        if (user == null || string.IsNullOrEmpty(user.userName) || string.IsNullOrEmpty(user.password))
        {
            return BadRequest("Invalid user data");
        }

        try
        {
            await _userService.RegisterUserAsync(user);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while registering the user");
        }
    }
}