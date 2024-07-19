using AspireDay.Domain.Features.Orders.CreateBuyOrder;
using AspireDay.Domain.Features.Orders.GetBuyOrders;

namespace AspireDay.WebApp.Clients;

public class StoreApiClient(HttpClient httpClient)
{
    public async Task<List<GetBuyOrderResponse>?> GetBuyOrdersAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<List<GetBuyOrderResponse>>($"/buy-order/{userId}", cancellationToken);
    }

    public async Task<CreateBuyOrderResponse?> CreateBuyOrderAsync(CreateBuyOrderModel buyRequest,
        CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/buy-order", buyRequest, cancellationToken);
        return await response.Content.ReadFromJsonAsync<CreateBuyOrderResponse>(cancellationToken: cancellationToken);
    }
}