using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface IRateRepository
{
    Task<Rate?> GetByIdsAsync(int customerId, string companyId, int pollId, CancellationToken ct = default);
    Task<IReadOnlyList<Rate>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(Rate rate, CancellationToken ct = default);
    Task UpdateAsync(Rate rate, CancellationToken ct = default);
    Task RemoveAsync(Rate rate, CancellationToken ct = default);
    Task<IReadOnlyList<Rate>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
