
namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product product);
internal class GetProductByIdHandler
    (IDocumentSession session )
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {

        var product = await session.LoadAsync<Product>(query.id, cancellationToken);

        if(product is null)
        {
            throw new ProductNotFoundException(query.id);
        }
        return new GetProductByIdResult(product);
    }
}
