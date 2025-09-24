using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Polls;

public sealed class CreatePollHandler(IPollRepository repo) : IRequestHandler<CreatePoll, int>
{
    public async Task<int> Handle(CreatePoll req, CancellationToken ct)
    {
        var poll = new Poll {
            Name = req.Name,
            Description = req.Description,
            IsActive = req.IsActive,
            CategoryPollId = req.CategoryPollId
        };
        await repo.AddAsync(poll, ct);
        return poll.Id;
    }
}
