using MediatR;

namespace Application.Favorites;

public sealed record CreateFavorite(int CustomerId, string CompanyId) : IRequest<int>;
