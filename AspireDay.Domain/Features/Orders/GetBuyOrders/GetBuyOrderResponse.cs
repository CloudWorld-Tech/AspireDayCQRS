namespace AspireDay.Domain.Features.Orders.GetBuyOrders;

public record GetBuyOrderResponse
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}