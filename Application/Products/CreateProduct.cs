using MediatR;

namespace Application.Products;

public sealed record CreateProduct(string Name, string Detail, double Price, int TypeProductId, string Image) : IRequest<int>;
