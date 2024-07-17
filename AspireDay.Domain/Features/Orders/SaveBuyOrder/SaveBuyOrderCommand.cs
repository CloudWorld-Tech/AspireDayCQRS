using MediatR;

namespace AspireDay.Domain.Features.Orders.SaveBuyOrder;

public record SaveBuyOrderCommand(SaveBuyOrderModel BuyOrder) : IRequest<SaveBuyOrderResponse>, IRequest;