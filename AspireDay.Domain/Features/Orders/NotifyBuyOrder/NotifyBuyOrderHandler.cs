using MediatR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

namespace AspireDay.Domain.Features.Orders.NotifyBuyOrder;

public class NotifyBuyOrderHandler([FromKeyedServices("AspireDaySignalR")] HubConnection hubConnection)
    : INotificationHandler<NotifyBuyOrderCommand>
{
    public async Task Handle(NotifyBuyOrderCommand request, CancellationToken cancellationToken)
    {
        await hubConnection.StartAsync(cancellationToken);
        await hubConnection.InvokeAsync("NotifyBuyOrder", request.ProductId.ToString(), cancellationToken);
    }
}