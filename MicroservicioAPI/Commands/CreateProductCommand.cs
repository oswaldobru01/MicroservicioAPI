using MediatR;

public record CreateProductCommand(string Nombre, decimal Precio) : IRequest<Guid>;