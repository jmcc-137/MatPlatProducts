using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.TypesProducts;

public sealed class CreateTypesProductHandler(ITypesProductRepository repo) : IRequestHandler<CreateTypesProduct, int>
{
    public async Task<int> Handle(CreateTypesProduct req, CancellationToken ct)
    {
        var typesProduct = new TypesProduct {
            Description = req.Description
        };
        await repo.AddAsync(typesProduct, ct);
        return typesProduct.Id;
    }
}
