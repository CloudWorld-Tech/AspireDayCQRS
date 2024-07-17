namespace AspireDay.Domain.Features.Orders.SaveBuyOrder;

public class SaveBuyOrderModel
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}