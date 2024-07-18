using MediatR;

namespace AspireDay.Domain.Features.Orders.NotifyBuyOrder;

public record NotifyBuyOrderCommand(Guid ProductId) : INotification;