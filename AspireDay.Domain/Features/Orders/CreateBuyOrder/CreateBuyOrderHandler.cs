using System.Text;
using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Mapster;
using MediatR;

namespace AspireDay.Domain.Features.Orders.CreateBuyOrder;

public class CreateBuyOrderHandler(ServiceBusClient client)
    : IRequestHandler<CreateBuyOrderCommand, CreateBuyOrderResponse>
{
    public async Task<CreateBuyOrderResponse> Handle(CreateBuyOrderCommand request, CancellationToken cancellationToken)
    {
        var sender = client.CreateSender("buy-order");
        await sender.SendMessageAsync(
            new ServiceBusMessage(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request.CreateBuyOrder))),
            cancellationToken);

        var response = request.CreateBuyOrder.Adapt<CreateBuyOrderResponse>();
        response.OrderId = Guid.NewGuid();
        response.Success = true;

        return response;
    }
}