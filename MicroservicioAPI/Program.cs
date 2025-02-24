using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de dependencias
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
builder.Services.AddMediatR(typeof(CreateProductHandler).Assembly);
builder.Services.AddControllers();

// 🔥 Configurar CORS correctamente **ANTES** de app.Build()
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Habilitar CORS antes de definir rutas
app.UseCors("AllowSpecificOrigin");

// Habilitar enrutamiento
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Configurar Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservicio API v1");
    c.RoutePrefix = string.Empty; // Para que Swagger se sirva en la raíz (http://localhost:7038)
});

// Definir endpoints
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
