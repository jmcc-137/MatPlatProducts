using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Categories;

public sealed class CreateCategoryHandler(ICategoryRepository repo) : IRequestHandler<CreateCategory, int>
{
    public async Task<int> Handle(CreateCategory req, CancellationToken ct)
    {
        var category = new Category { Description = req.Description };
        await repo.AddAsync(category, ct);
        return category.Id;
    }
}
