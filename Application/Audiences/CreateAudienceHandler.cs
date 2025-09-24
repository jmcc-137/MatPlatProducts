using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Audiences;

public sealed class CreateAudienceHandler(IAudienceRepository repo) : IRequestHandler<CreateAudience, int>
{
    public async Task<int> Handle(CreateAudience req, CancellationToken ct)
    {
        var audience = new Audience { Description = req.Description };
        await repo.AddAsync(audience, ct);
        return audience.Id;
    }
}
