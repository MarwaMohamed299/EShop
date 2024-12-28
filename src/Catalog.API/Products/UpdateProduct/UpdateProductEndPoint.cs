namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
public record UpdateProductResponse(bool IsSuccess);

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
        {
            // Use constructor with required parameters
            var command = new UpdateProductCommand(
                request.Id,
                request.Name,
                request.Category,
                request.Description,
                request.ImageFile,
                request.Price
            );

            var result = await sender.Send(command);

            // Validate `UpdateProductResult` structure
            var response = new UpdateProductResponse(result.IsSuccess);

            return Results.Ok(response);
        })
.WithName("UpdateProduct")
.Produces<UpdateProductResponse>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status400BadRequest)
.ProducesProblem(StatusCodes.Status404NotFound)
.WithSummary("Update Product")
.WithDescription("Update Product");
    }
}
