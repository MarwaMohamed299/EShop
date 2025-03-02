using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.QueryHandlers.GetOrder
{
    public record GetOrdersQuery(PaginationRequest PaginationRequest)
    : IQuery<GetOrdersResult>;

    public record GetOrdersResult(PaginatedResult<OrderDto> Orders);
}
