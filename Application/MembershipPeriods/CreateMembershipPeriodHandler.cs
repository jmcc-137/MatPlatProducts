using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.MembershipPeriods;

public sealed class CreateMembershipPeriodHandler(IMembershipPeriodRepository repo) : IRequestHandler<CreateMembershipPeriod, int>
{
    public async Task<int> Handle(CreateMembershipPeriod req, CancellationToken ct)
    {
        var mp = new MembershipPeriod {
            MembershipId = req.MembershipId,
            PeriodId = req.PeriodId,
            Name = req.Name,
            Description = req.Description,
            Price = req.Price,
            CompanyId = req.CompanyId
        };
        await repo.AddAsync(mp, ct);
        return mp.Id;
    }
}
