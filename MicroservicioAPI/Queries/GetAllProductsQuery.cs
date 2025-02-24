using MediatR;

public record GetAllProductsQuery() : IRequest<IEnumerable<Product>>;