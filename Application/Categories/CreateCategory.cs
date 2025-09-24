using MediatR;

namespace Application.Categories;

public sealed record CreateCategory(string Description) : IRequest<int>;
