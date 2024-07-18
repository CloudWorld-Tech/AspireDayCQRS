using Microsoft.AspNetCore.SignalR;

namespace AspireDay.Domain.Hubs;

public class StoreHub : Hub
{
    public async Task NotifyBuyOrder(string user, string message)
        => await Clients.All.SendAsync("NotifyBuyOrder", user, message);
}