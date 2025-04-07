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
        await messageService.SendMessageAsync(message);
        return Ok(message);
    }
}