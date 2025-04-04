namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record GetProductResponse(Guid Id);

    public class CreateProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products",
                async (CreateProductRequest request, ISender sender) =>
                {
                    // Ensure you're passing the correct parameters for the command
                    var command = new CreateProductCommand(
                        request.Name, // Pass Name as a parameter to the constructor
                        request.Category,
                        request.Description,
                        request.ImageFile,
                        request.Price
                    );

                    var result = await sender.Send(command);

                    // Manually map CreateProductResult to GetProductResponse
                    var response = new GetProductResponse(result.Id); 

                    return Results.Created($"/products/{response.Id}", response);
                })
                .WithName("CreateProduct")
                .Produces<GetProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Product")
                .WithDescription("Create Product");
        }
    }
}
