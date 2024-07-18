using AspireDay.Domain.Features.Orders.CreateBuyOrder;
using AspireDay.Domain.Features.Orders.NotifyBuyOrder;
using AspireDay.Domain.Features.Orders.SaveBuyOrder;
using Azure.Messaging.ServiceBus;
using Mapster;
using MediatR;

namespace AspireDay.WorkerService;

public class Worker(ILogger<Worker> logger, ServiceBusClient client, IMediator mediator) : BackgroundService
{
    private readonly ServiceBusReceiver _receiver = client.CreateReceiver("buy-order");

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
            await foreach (var serviceBusReceivedMessage in _receiver.ReceiveMessagesAsync(stoppingToken))
            {
                var message = serviceBusReceivedMessage.Body.ToObjectFromJson<CreateBuyOrderResponse>();
                logger.LogInformation("Received message {Hour}: {message}", DateTimeOffset.Now, message);
                await mediator.Send(new SaveBuyOrderCommand(message.Adapt<SaveBuyOrderModel>()), stoppingToken);
                await _receiver.CompleteMessageAsync(serviceBusReceivedMessage, stoppingToken);
                await mediator.Send(new NotifyBuyOrderCommand(), stoppingToken);
            }
    }
}