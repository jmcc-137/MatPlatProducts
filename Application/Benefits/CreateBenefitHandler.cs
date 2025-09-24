using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Benefits;

public sealed class CreateBenefitHandler(IBenefitRepository repo) : IRequestHandler<CreateBenefit, int>
{
    public async Task<int> Handle(CreateBenefit req, CancellationToken ct)
    {
        var benefit = new Benefit { Description = req.Description, Detail = req.Detail };
        await repo.AddAsync(benefit, ct);
        return benefit.Id;
    }
}
