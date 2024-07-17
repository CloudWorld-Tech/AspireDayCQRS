using AspireDay.Domain.Features.Orders.GetBuyOrders;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AspireDay.WebApi.Features.Store.GetBuyOrders;

public static class GetBuyOrdersEndpoint
{
    public static IEndpointRouteBuilder AddGetBuyOrdersEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("buy-order/{userId:guid}", async ([FromRoute] Guid userId,
                [FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(new GetBuyOrdersQuery(userId));
                return result;
            })
            .WithName("GetBuyOrders")
            .Produces<Ok<List<GetBuyOrderResponse>>>()
            .WithOpenApi();

        return builder;
    }
}