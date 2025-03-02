namespace Ordering.Application.Orders.QueryHandlers.GetOrdersByCustomers
{
    public record GetOrdersByCustomerQuery(Guid CustomerId)
    : IQuery<GetOrdersByCustomerResult>;

    public record GetOrdersByCustomerResult(IEnumerable<OrderDto> Orders);
}
