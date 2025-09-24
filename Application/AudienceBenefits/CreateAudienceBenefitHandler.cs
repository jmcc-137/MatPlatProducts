using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.AudienceBenefits;

public sealed class CreateAudienceBenefitHandler(IAudienceBenefitRepository repo) : IRequestHandler<CreateAudienceBenefit, (int AudienceId, int BenefitId)>
{
    public async Task<(int AudienceId, int BenefitId)> Handle(CreateAudienceBenefit req, CancellationToken ct)
    {
        var ab = new AudienceBenefit { AudienceId = req.AudienceId, BenefitId = req.BenefitId };
        await repo.AddAsync(ab, ct);
        return (ab.AudienceId, ab.BenefitId);
    }
}
