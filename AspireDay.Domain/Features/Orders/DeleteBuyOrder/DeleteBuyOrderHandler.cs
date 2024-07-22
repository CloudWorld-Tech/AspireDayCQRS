using AspireDay.Domain.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspireDay.Domain.Features.Orders.DeleteBuyOrder;

public class DeleteBuyOrderHandler(StoreDbContext dbContext)
    : IRequestHandler<DeleteBuyOrderCommand, DeleteBuyOrderResponse>
{
    public async Task<DeleteBuyOrderResponse> Handle(DeleteBuyOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await dbContext.BuyOrders.SingleOrDefaultAsync(x => x.OrderId == request.OrderId,
            cancellationToken: cancellationToken);

        if (order is null)
        {
            return new DeleteBuyOrderResponse { Status = false, OrderId = request.OrderId};
        }

        dbContext.BuyOrders.Remove(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteBuyOrderResponse { Status = true, OrderId = order.ProductId };
    }
}