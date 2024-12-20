

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommmand(string Name , List<string> Category , string Description ,string ImageFile , decimal Price) 
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler (IDocumentSession session)
        : ICommandHandler<CreateProductCommmand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommmand command, CancellationToken cancellationToken)
        {

            var product = new Product()
            {  
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return  new CreateProductResult(Guid.NewGuid());
        }
    }
}
