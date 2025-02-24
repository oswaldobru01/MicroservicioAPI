using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de dependencias
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
builder.Services.AddMediatR(typeof(CreateProductHandler).Assembly);
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSwagger();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservicio API v1");
    c.RoutePrefix = string.Empty;
});

app.MapPost("/CrearProductos", async (CreateProductDto dto, IMediator mediator) =>
{
    var command = new CreateProductCommand(dto.Nombre, dto.Precio);
    var productId = await mediator.Send(command);
    return Results.Ok(productId);
});

app.MapGet("/ObtenerProductos", async (IMediator mediator) =>
{
    var products = await mediator.Send(new GetAllProductsQuery());
    return Results.Ok(products);
});

app.Run();
