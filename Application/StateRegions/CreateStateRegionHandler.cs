using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.StateRegions;

public sealed class CreateStateRegionHandler(IStateRegionRepository repo) : IRequestHandler<CreateStateRegion, string>
{
    public async Task<string> Handle(CreateStateRegion req, CancellationToken ct)
    {
        var stateRegion = new StateRegion {
            Code = req.Code,
            Name = req.Name,
            CountryId = req.CountryId,
            Code3166 = req.Code3166,
            StateRegId = req.StateRegId,
            SubdivisionId = req.SubdivisionId
        };
        await repo.AddAsync(stateRegion, ct);
        return stateRegion.Code;
    }
}
