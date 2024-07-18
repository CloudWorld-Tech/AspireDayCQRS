using MediatR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

namespace AspireDay.Domain.Features.Orders.NotifyBuyOrder;

public class NotifyBuyOrderHandler([FromKeyedServices("AspireDaySignalR")] HubConnection hubConnection)
    : IRequestHandler<NotifyBuyOrderCommand>
{
    public async Task Handle(NotifyBuyOrderCommand request, CancellationToken cancellationToken)
    {
        await hubConnection.StartAsync(cancellationToken);
        await hubConnection.InvokeAsync("NotifyBuyOrder","Test","Message", cancellationToken);
    }
}