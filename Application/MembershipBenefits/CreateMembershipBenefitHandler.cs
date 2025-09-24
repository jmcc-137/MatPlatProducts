using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.MembershipBenefits;

public sealed class CreateMembershipBenefitHandler(IMembershipBenefitRepository repo) : IRequestHandler<CreateMembershipBenefit, int>
{
    public async Task<int> Handle(CreateMembershipBenefit req, CancellationToken ct)
    {
        var mb = new MembershipBenefit {
            MembershipPeriodId = req.MembershipPeriodId,
            BenefitId = req.BenefitId
        };
        await repo.AddAsync(mb, ct);
        return mb.Id;
    }
}
