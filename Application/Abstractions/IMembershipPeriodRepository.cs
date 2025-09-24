using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface IMembershipPeriodRepository
{
    Task<MembershipPeriod?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<MembershipPeriod>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(MembershipPeriod period, CancellationToken ct = default);
    Task UpdateAsync(MembershipPeriod period, CancellationToken ct = default);
    Task RemoveAsync(MembershipPeriod period, CancellationToken ct = default);
    Task<IReadOnlyList<MembershipPeriod>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
