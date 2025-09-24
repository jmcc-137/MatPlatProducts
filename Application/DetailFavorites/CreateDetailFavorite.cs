using MediatR;

namespace Application.DetailFavorites;

public sealed record CreateDetailFavorite(int FavoriteId, int ProductId) : IRequest<int>;
