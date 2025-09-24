using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface IMembershipBenefitRepository
{
    Task<MembershipBenefit?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<MembershipBenefit>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(MembershipBenefit benefit, CancellationToken ct = default);
    Task UpdateAsync(MembershipBenefit benefit, CancellationToken ct = default);
    Task RemoveAsync(MembershipBenefit benefit, CancellationToken ct = default);
    Task<IReadOnlyList<MembershipBenefit>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
