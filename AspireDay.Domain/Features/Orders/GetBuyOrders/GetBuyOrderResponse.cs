namespace AspireDay.Domain.Features.Orders.GetBuyOrders;

public record GetBuyOrderResponse
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; init; }
    public Guid UserId { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}