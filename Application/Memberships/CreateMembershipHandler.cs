using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Memberships;

public sealed class CreateMembershipHandler(IMembershipRepository repo) : IRequestHandler<CreateMembership, int>
{
    public async Task<int> Handle(CreateMembership req, CancellationToken ct)
    {
        var membership = new Membership {
            Name = req.Name,
            Description = req.Description
        };
        await repo.AddAsync(membership, ct);
        return membership.Id;
    }
}
