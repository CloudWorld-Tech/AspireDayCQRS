using MediatR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

namespace AspireDay.Domain.Features.Orders.NotifyDeleteBuyOrder;

public class NotifyDeleteBuyOrderHandler([FromKeyedServices("AspireDaySignalR")] HubConnection hubConnection)
    : INotificationHandler<NotifyDeleteOrderCommand>
{
    public async Task Handle(NotifyDeleteOrderCommand request, CancellationToken cancellationToken)
    {
        await hubConnection.StartAsync(cancellationToken);
        await hubConnection.InvokeAsync("NotifyBuyOrder", request.ProductId.ToString(), cancellationToken);
    }
}