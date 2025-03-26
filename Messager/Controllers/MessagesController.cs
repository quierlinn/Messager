using Messager.Data;
using Messager.Models;
using Microsoft.AspNetCore.Mvc;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly ChatContext context;

    public MessagesController(ChatContext context)
    {
        this.context = context;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] Message message)
    {
        context.Messages.Add(message);
        await context.SaveChangesAsync();
        return Ok(message);
    }
}