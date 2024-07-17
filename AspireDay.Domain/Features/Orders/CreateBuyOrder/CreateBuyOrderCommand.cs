using MediatR;

namespace AspireDay.Domain.Features.Orders.CreateBuyOrder;

public record CreateBuyOrderCommand(CreateBuyOrderModel CreateBuyOrder) : IRequest<CreateBuyOrderResponse>;