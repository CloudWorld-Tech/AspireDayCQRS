namespace AspireDay.Domain.Features.Orders.CreateBuyOrder;

public record CreateBuyOrderModel
{
    public Guid ProductId { get; init; }
    public Guid UserId { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}