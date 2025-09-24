using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Periods;

public sealed class CreatePeriodHandler(IPeriodRepository repo) : IRequestHandler<CreatePeriod, int>
{
    public async Task<int> Handle(CreatePeriod req, CancellationToken ct)
    {
        var period = new Period {
            Name = req.Name
        };
        await repo.AddAsync(period, ct);
        return period.Id;
    }
}
