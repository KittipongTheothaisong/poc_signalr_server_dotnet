using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
namespace poc_signalr_server_dotnet;

[ApiController]
[Route("[controller]")]
public class MessageController(IHubContext<MessageHub> hubContext) : ControllerBase
{
    [HttpPost("SendMessage")]
    public async Task<IActionResult> SendMessage([FromBody] Message message)
    {
        Console.WriteLine($"Received message: {message.Text}");
        await hubContext.Clients.All.SendAsync("MessageReceived", message.Text);

        return Ok();
    }

    [HttpGet("GetMessage")]
    public async Task<IActionResult> GetMessage()
    {
        await hubContext.Clients.All.SendAsync("MessageReceived", "Get Message called");

        return Ok("Hello from MessageController");
    }
}

