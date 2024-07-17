namespace AspireDay.Domain.Features.Orders.CreateBuyOrder;

public class CreateBuyOrderResponse
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public bool Success { get; set; }
}