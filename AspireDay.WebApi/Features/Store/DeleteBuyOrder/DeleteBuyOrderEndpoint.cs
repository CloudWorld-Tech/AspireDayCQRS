using AspireDay.Domain.Features.Orders.DeleteBuyOrder;
using AspireDay.Domain.Features.Orders.NotifyBuyOrder;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AspireDay.WebApi.Features.Store.DeleteBuyOrder;

public static class DeleteBuyOrderEndpoint
{
    public static IEndpointRouteBuilder AddDeleteBuyOrderEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapDelete("/{id:guid}", async ([FromRoute] Guid id,
                [FromServices] IMediator mediator, CancellationToken cancellationToken = default) =>
            {
                var response = await mediator.Send(new DeleteBuyOrderCommand(id), cancellationToken);
                await mediator.Publish(new NotifyBuyOrderCommand(response.OrderId), cancellationToken);
                return Results.Ok(response);
            })
            .WithName("DeleteBuyOrder")
            .Produces<Ok<DeleteBuyOrderResponse>>()
            .WithOpenApi();

        return builder;
    }
}