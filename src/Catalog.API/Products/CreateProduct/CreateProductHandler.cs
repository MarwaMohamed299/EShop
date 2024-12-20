using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommmand(string Name , List<string> Category , string Description ,string ImageFile , decimal Price) 
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommmand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommmand command, CancellationToken cancellationToken)
        {
            //create product 
            //save to db
            // return CreateProductresult

            var product = new Product()
            {  
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
