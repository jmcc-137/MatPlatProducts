using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Rates;

public sealed class CreateRateHandler(IRateRepository repo) : IRequestHandler<CreateRate, (int CustomerId, string CompanyId, int PollId)>
{
    public async Task<(int CustomerId, string CompanyId, int PollId)> Handle(CreateRate req, CancellationToken ct)
    {
        var rate = new Rate {
            CustomerId = req.CustomerId,
            CompanyId = req.CompanyId,
            PollId = req.PollId,
            DataRating = req.DataRating,
            Rating = req.Rating
        };
        await repo.AddAsync(rate, ct);
        return (rate.CustomerId, rate.CompanyId, rate.PollId);
    }
}
