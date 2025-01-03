using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductRequest(int? PageNumber, int? PageSize = 10);
    public record GetProductsResponse(IEnumerable<Product> products);
    public class GetProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters]GetProductRequest request ,ISender sender) =>
            {
                var query = request.Adapt<GetProductQuery>();

                var result = await sender.Send(query);

                var response = new GetProductsResponse(result.products);

                return Results.Ok(response);
            })
            .WithName("GetProduct")
                .Produces<GetProductResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Product")
                .WithDescription("Get Product");

        }
    }
}
