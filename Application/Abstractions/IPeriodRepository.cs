using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface IPeriodRepository
{
    Task<Period?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<Period>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(Period period, CancellationToken ct = default);
    Task UpdateAsync(Period period, CancellationToken ct = default);
    Task RemoveAsync(Period period, CancellationToken ct = default);
    Task<IReadOnlyList<Period>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
