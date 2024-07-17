using AspireDay.Domain.Persistence;
using AspireDay.Domain.Persistence.Models;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AspireDay.Domain.Features.Orders.SaveBuyOrder;

public class SaveBuyOrderHandler(IServiceScopeFactory serviceScopeFactory) : IRequestHandler<SaveBuyOrderCommand>
{
    public async Task Handle(SaveBuyOrderCommand request, CancellationToken cancellationToken)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
        var data = request.BuyOrder.Adapt<BuyOrder>();
        await context.BuyOrders.AddAsync(data, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}