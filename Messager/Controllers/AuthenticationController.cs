using Messager.Data;
using Messager.Models;
using Microsoft.AspNetCore.Mvc;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]
public class AuthenticationController(ChatContext context) : ControllerBase
{
    private readonly ChatContext context = context;

    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return Ok(user);
    }
    
}