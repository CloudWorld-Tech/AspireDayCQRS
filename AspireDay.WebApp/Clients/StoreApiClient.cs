using AspireDay.Domain.Features.Orders.GetBuyOrders;

namespace AspireDay.WebApp.Clients;

public class StoreApiClient(HttpClient httpClient)
{
    public async Task<GetBuyOrderResponse[]?> GetBuyOrdersAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<GetBuyOrderResponse[]>($"/buy-order/{userId}", cancellationToken);
    }
}