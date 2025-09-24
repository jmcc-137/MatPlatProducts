using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.UnitOfMeasures;

public sealed class CreateUnitOfMeasureHandler(IUnitOfMeasureRepository repo) : IRequestHandler<CreateUnitOfMeasure, int>
{
    public async Task<int> Handle(CreateUnitOfMeasure req, CancellationToken ct)
    {
        var unit = new UnitOfMeasure {
            Description = req.Description
        };
        await repo.AddAsync(unit, ct);
        return unit.Id;
    }
}
