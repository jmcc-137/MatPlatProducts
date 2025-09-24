using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.DetailFavorites;

public sealed class CreateDetailFavoriteHandler(IDetailFavoriteRepository repo) : IRequestHandler<CreateDetailFavorite, int>
{
    public async Task<int> Handle(CreateDetailFavorite req, CancellationToken ct)
    {
        var detailFavorite = new DetailFavorite {
            FavoriteId = req.FavoriteId,
            ProductId = req.ProductId
        };
        await repo.AddAsync(detailFavorite, ct);
        return detailFavorite.Id;
    }
}
