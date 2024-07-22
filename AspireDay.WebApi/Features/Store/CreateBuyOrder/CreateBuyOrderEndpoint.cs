using AspireDay.Domain.Features.Orders.CreateBuyOrder;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AspireDay.WebApi.Features.Store.CreateBuyOrder;

public static class CreateBuyOrderEndpoint
{
    public static IEndpointRouteBuilder AddCreateBuyOrderEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("/", async ([FromBody] CreateBuyOrderModel buyRequest,
                [FromServices] IMediator mediator, CancellationToken cancellationToken = default) =>
            {
                var response = await mediator.Send(new CreateBuyOrderCommand(buyRequest), cancellationToken);
                return Results.Ok(response);
            })
            .WithName("BuyOrder")
            .Produces<Ok<CreateBuyOrderResponse>>()
            .WithOpenApi();

        return builder;
    }
}