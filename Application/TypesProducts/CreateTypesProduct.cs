using MediatR;

namespace Application.TypesProducts;

public sealed record CreateTypesProduct(string Description) : IRequest<int>;
