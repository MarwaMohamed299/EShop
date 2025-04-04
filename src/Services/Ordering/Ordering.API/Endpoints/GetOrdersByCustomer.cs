using Ordering.Application.Orders.Queries.GetOrdersByCustomer;
public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);


public class GetOrdersByCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/customer/{customerId}", async (Guid customerId, ISender sender) =>
        {
            // Fetch the orders
            var result = await sender.Send(new GetOrdersByCustomerQuery(customerId));

            // Check if result is null or contains no orders
            if (result?.Orders == null || !result.Orders.Any())
            {
                return Results.Ok(new GetOrdersByCustomerResponse(Enumerable.Empty<OrderDto>()));
            }

            // Map the orders to OrderDto and return the response
            var response = new GetOrdersByCustomerResponse(
                result.Orders.Select(order => new OrderDto(
                    order.Id,                     // Pass Id
                    order.CustomerId,             // Pass CustomerId
                    order.OrderName,              // Pass OrderName
                    order.BillingAddress,         // Pass BillingAddress
                    order.ShippingAddress,        // Pass ShippingAddress
                    order.Payment,                // Pass Payment
                    order.Status,                 // Pass Status
                    order.OrderItems              // Pass OrderItems
                ))
            );

            return Results.Ok(response);
        })
        .WithName("GetOrdersByCustomer")
        .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Orders By Customer")
        .WithDescription("Get Orders By Customer");
    }
}
