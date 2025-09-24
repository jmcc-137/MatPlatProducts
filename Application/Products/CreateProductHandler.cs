using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Products;

public sealed class CreateProductHandler(IProductRepository repo) : IRequestHandler<CreateProduct, int>
{
    public async Task<int> Handle(CreateProduct req, CancellationToken ct)
    {
        var product = new Product {
            Name = req.Name,
            Detail = req.Detail,
            Price = req.Price,
            TypeProductId = req.TypeProductId,
            Image = req.Image
        };
        await repo.AddAsync(product, ct);
        return product.Id;
    }
}
