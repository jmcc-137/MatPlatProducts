using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.TypeIdentifications;

public sealed class CreateTypeIdentificationHandler(ITypeIdentificationRepository repo) : IRequestHandler<CreateTypeIdentification, int>
{
    public async Task<int> Handle(CreateTypeIdentification req, CancellationToken ct)
    {
        var typeIdentification = new TypeIdentification {
            Description = req.Description,
            Suffix = req.Suffix
        };
        await repo.AddAsync(typeIdentification, ct);
        return typeIdentification.Id;
    }
}
