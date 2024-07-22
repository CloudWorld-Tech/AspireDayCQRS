using MediatR;

namespace AspireDay.Domain.Features.Orders.NotifyDeleteBuyOrder;

public record NotifyDeleteOrderCommand(Guid ProductId) : INotification;