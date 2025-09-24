using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface IMembershipRepository
{
    Task<Membership?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<Membership>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(Membership membership, CancellationToken ct = default);
    Task UpdateAsync(Membership membership, CancellationToken ct = default);
    Task RemoveAsync(Membership membership, CancellationToken ct = default);
    Task<IReadOnlyList<Membership>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
