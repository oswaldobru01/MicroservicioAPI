using MediatR;

public static class ProductEndpoints
{
    public static void ConfigureProductEndpoints(this WebApplication app)
    {
        app.MapPost("/products", async (CreateProductDto dto, IMediator mediator) =>
        {
            var command = new CreateProductCommand(dto.Nombre, dto.Precio);
            var productId = await mediator.Send(command);
            return Results.Ok(productId);
        });

        app.MapGet("/products", async (IMediator mediator) =>
        {
            var products = await mediator.Send(new GetAllProductsQuery());
            return Results.Ok(products);
        });
    }
}