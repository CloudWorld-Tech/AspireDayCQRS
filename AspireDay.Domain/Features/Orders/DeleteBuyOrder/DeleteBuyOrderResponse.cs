namespace AspireDay.Domain.Features.Orders.DeleteBuyOrder;

public class DeleteBuyOrderResponse
{
    public bool Status { get; set; }
    public Guid OrderId { get; set; }
}