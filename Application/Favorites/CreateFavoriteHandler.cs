using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Favorites;

public sealed class CreateFavoriteHandler(IFavoriteRepository repo) : IRequestHandler<CreateFavorite, int>
{
    public async Task<int> Handle(CreateFavorite req, CancellationToken ct)
    {
        var favorite = new Favorite {
            CustomerId = req.CustomerId,
            CompanyId = req.CompanyId
        };
        await repo.AddAsync(favorite, ct);
        return favorite.Id;
    }
}
