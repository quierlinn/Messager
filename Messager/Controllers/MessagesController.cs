using Messager.Data;
using Messager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly ChatContext context;

    public MessagesController(ChatContext context)
    {
        this.context = context;
    }

    [HttpPost("sendMessage")]
    public async Task<IActionResult> SendMessage([FromBody] Message message)
    {
        var senderExists = await context.Users.AnyAsync(u => u.id == message.senderId);
        var receiverExists = await context.Users.AnyAsync(u => u.id == message.receiverId);

        if (!senderExists)
        {
            return NotFound($"Sender with ID {message.senderId} not found.");
        }

        if (!receiverExists)
        {
            return NotFound($"Receiver with ID {message.receiverId} not found.");
        }

        context.Messages.Add(message);
        await context.SaveChangesAsync();

        return Ok(message);
    }
}