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
}

