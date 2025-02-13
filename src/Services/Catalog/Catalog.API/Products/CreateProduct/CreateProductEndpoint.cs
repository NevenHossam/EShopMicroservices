namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(Guid Id, string Name, List<string> Category, string Desc, string ImgFile,
    decimal Price) : ICommand<CreateProductResult>;

    public record CreateProductResponse(Guid Id);

    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest req, ISender sender) =>
            {
                var prd = req.Adapt<CreateProductCommand>();
                var result = await sender.Send(prd);
                var res = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{res.Id}", res);
            })
            .WithDescription("Create Product")
            .WithName("CreateProduct")
            .Produces<CreateProductRequest>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}

