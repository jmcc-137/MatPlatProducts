using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.CompanyProducts;

public sealed class CreateCompanyProductHandler(ICompanyProductRepository repo) : IRequestHandler<CreateCompanyProduct, (string CompanyId, int ProductId)>
{
    public async Task<(string CompanyId, int ProductId)> Handle(CreateCompanyProduct req, CancellationToken ct)
    {
        var cp = new CompanyProduct {
            CompanyId = req.CompanyId,
            ProductId = req.ProductId,
            Price = req.Price,
            UnitMeasureId = req.UnitMeasureId
        };
        await repo.AddAsync(cp, ct);
        return (cp.CompanyId, cp.ProductId);
    }
}
