using MediatR;

namespace AspireDay.Domain.Features.Orders.GetBuyOrders;

public record GetBuyOrdersQuery(Guid UserId) : IRequest<List<GetBuyOrderResponse>>;