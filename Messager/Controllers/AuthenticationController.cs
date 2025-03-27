using Messager.Data;
using Messager.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly ChatContext context;

    public AuthenticationController(ChatContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        if (user == null || string.IsNullOrEmpty(user.userName) || string.IsNullOrEmpty(user.password))
        {
            return BadRequest("User  object, User Name, and Password are required.");
        }

        context.Users.Add(user);
        await context.SaveChangesAsync();
        return Ok(user);
    }
}