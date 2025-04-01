using Messager.Data;
using Messager.Messager.Services;
using Messager.Messager.Services.Abstractions;
using Messager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IMessageService messageService;

    public MessagesController(IMessageService messageService)
    {
        this.messageService = messageService;
    }

    [HttpPost("sendMessage")]
    public async Task<IActionResult> SendMessage([FromBody] Message message)
    {
        if (message == null)
        {
            return BadRequest("Message object is required");
        }

        try
        {
            await messageService.SendMessageAsync(message);
            return Ok(message);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}