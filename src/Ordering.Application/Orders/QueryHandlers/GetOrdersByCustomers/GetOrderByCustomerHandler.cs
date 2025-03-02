using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Orders.QueryHandlers.GetOrdersByCustomers
{
    public class GetOrdersByCustomerHandler(IAppDbContext dbContext)
    : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResult>
    {
        public async Task<GetOrdersByCustomerResult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
        {

            var orders = await dbContext.Orders
                            .Include(o => o.OrderItems)
                            .AsNoTracking()
                            .Where(o => o.CustomerId == CustomerId.Of(query.CustomerId))  //strongly typed
                            .OrderBy(o => o.OrderName.Value)
                            .ToListAsync(cancellationToken);

            return new GetOrdersByCustomerResult(orders.ToOrderDtoList());
        }
    }
}
