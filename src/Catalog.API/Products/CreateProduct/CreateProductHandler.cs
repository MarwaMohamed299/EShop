namespace Catalog.API.Products.CreateProduct
{
    #region records 
    public record CreateProductCommmand(string Name , List<string> Category , string Description , string ImageFile , decimal Price) 
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    #endregion

    #region  Fluent Validation
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommmand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required ");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is Required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage(" Price must be greater than 0");
        }
    }
    #endregion

    #region Handler
    internal class CreateProductCommandHandler (IDocumentSession session , IValidator<CreateProductCommmand> validator)
        : ICommandHandler<CreateProductCommmand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommmand command, CancellationToken cancellationToken)
        {
            var result = await validator.ValidateAsync(command , cancellationToken);

            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
            if (errors.Any())
            {
                throw new ValidationException(errors.FirstOrDefault());
            }

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
    #endregion
}
