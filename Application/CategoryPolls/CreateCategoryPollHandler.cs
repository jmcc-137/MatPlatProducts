using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.CategoryPolls;

public sealed class CreateCategoryPollHandler(ICategoryPollRepository repo) : IRequestHandler<CreateCategoryPoll, int>
{
    public async Task<int> Handle(CreateCategoryPoll req, CancellationToken ct)
    {
        var categoryPoll = new CategoryPoll { Name = req.Name };
        await repo.AddAsync(categoryPoll, ct);
        return categoryPoll.Id;
    }
}
