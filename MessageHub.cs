using Microsoft.AspNetCore.SignalR;
namespace poc_signalr_server_dotnet
{
    public sealed class MessageHub : Hub
    {
        public async Task SendMessageHub(string message)
        {
            await Clients.All.SendAsync("MessageReceived", message);
        }
    }
}