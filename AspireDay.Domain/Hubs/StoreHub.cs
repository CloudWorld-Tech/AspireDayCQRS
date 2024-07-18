using Microsoft.AspNetCore.SignalR;

namespace AspireDay.Domain.Hubs;

public class StoreHub : Hub
{
    public async Task NotifyBuyOrder(string orderId)
    {
        await Clients.All.SendAsync("NotifyBuyOrder", orderId);
    }
}