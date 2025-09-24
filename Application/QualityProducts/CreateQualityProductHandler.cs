using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.QualityProducts;

public sealed class CreateQualityProductHandler(IQualityProductRepository repo) : IRequestHandler<CreateQualityProduct, (int ProductId, int CustomerId, int PollId, string CompanyId)>
{
    public async Task<(int ProductId, int CustomerId, int PollId, string CompanyId)> Handle(CreateQualityProduct req, CancellationToken ct)
    {
        var qp = new QualityProduct {
            ProductId = req.ProductId,
            CustomerId = req.CustomerId,
            PollId = req.PollId,
            CompanyId = req.CompanyId,
            DataRating = req.DataRating,
            Rating = req.Rating
        };
        await repo.AddAsync(qp, ct);
        return (qp.ProductId, qp.CustomerId, qp.PollId, qp.CompanyId);
    }
}
