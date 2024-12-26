
namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product product);
internal class GetProductByIdHandler
    (IDocumentSession session , ILogger<GetProductByIdResult> logger)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get ProductByIdQueryHandler.Handle callsed with {@Query}", query);

        var product = await session.LoadAsync<Product>(query.id, cancellationToken);

        if(product is null)
        {
            throw new ProductNotFoundException();
        }
        return new GetProductByIdResult(product);
    }
}
