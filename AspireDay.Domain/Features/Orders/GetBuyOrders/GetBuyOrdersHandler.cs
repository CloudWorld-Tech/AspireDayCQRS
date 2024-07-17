using AspireDay.Domain.Persistence;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspireDay.Domain.Features.Orders.GetBuyOrders;

public class GetBuyOrdersHandler(StoreDbContext storeDbContext)
    : IRequestHandler<GetBuyOrdersQuery, List<GetBuyOrderResponse>>
{
    public async Task<List<GetBuyOrderResponse>> Handle(GetBuyOrdersQuery request, CancellationToken cancellationToken)
    {
        var items = await storeDbContext.BuyOrders.Where(x => x.UserId == request.UserId)
            .ToListAsync(cancellationToken);

        return items.Adapt<List<GetBuyOrderResponse>>();
    }
}