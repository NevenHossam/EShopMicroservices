using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{
	public record CreateProductCommand(Guid Id, string Name, List<string> Category, string Desc, string ImgFile,
        decimal Price):ICommand<CreateProductResult>;

	public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            Product prd = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Desc = command.Desc,
                ImgFile = command.ImgFile,
                Price = command.Price
            };
            //save in db
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}

