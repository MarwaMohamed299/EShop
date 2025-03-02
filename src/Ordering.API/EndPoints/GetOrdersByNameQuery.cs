
namespace Ordering.API.EndPoints
{
    internal class GetOrdersByNameQuery : IRequest<object>
    {
        private string orderName;

        public GetOrdersByNameQuery(string orderName)
        {
            this.orderName = orderName;
        }
    }
}