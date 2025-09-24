using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface IBenefitRepository
{
    Task<Benefit?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<Benefit>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(Benefit benefit, CancellationToken ct = default);
    Task UpdateAsync(Benefit benefit, CancellationToken ct = default);
    Task RemoveAsync(Benefit benefit, CancellationToken ct = default);
    Task<IReadOnlyList<Benefit>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
