using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommmand(string Name , List<string> Category , string Description ,string ImageFile , decimal Price) : IRequest<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommmand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommmand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
