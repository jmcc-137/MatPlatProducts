using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface ICategoryPollRepository
{
    Task<CategoryPoll?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<CategoryPoll>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(CategoryPoll categoryPoll, CancellationToken ct = default);
    Task UpdateAsync(CategoryPoll categoryPoll, CancellationToken ct = default);
    Task RemoveAsync(CategoryPoll categoryPoll, CancellationToken ct = default);
    Task<IReadOnlyList<CategoryPoll>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
