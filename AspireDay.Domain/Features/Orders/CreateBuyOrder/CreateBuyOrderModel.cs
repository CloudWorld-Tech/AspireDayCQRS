namespace AspireDay.Domain.Features.Orders.CreateBuyOrder;

public record CreateBuyOrderModel
{
    public string ProductId { get; set; }
    public string UserId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}