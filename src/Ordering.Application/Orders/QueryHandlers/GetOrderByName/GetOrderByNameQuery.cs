

namespace Ordering.Application.Orders.QueryHandlers.GetORderByName
{
    public record GetOrdersByNameQuery(string Name)
     : IQuery<GetOrdersByNameResult>;

    public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);
}
