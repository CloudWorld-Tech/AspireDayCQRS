namespace AspireDay.Domain.Persistence.Models;

public class BuyOrder
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; init; }
    public Guid UserId { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}