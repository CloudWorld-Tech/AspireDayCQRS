using MediatR;

namespace AspireDay.Domain.Features.Orders.DeleteBuyOrder;

public record DeleteBuyOrderCommand(Guid OrderId) : IRequest<DeleteBuyOrderResponse>;