using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface IPollRepository
{
    Task<Poll?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<Poll>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(Poll poll, CancellationToken ct = default);
    Task UpdateAsync(Poll poll, CancellationToken ct = default);
    Task RemoveAsync(Poll poll, CancellationToken ct = default);
    Task<IReadOnlyList<Poll>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
