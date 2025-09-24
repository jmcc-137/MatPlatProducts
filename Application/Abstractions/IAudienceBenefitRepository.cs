using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface IAudienceBenefitRepository
{
    Task<AudienceBenefit?> GetByIdsAsync(int audienceId, int benefitId, CancellationToken ct = default);
    Task<IReadOnlyList<AudienceBenefit>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(AudienceBenefit audienceBenefit, CancellationToken ct = default);
    Task UpdateAsync(AudienceBenefit audienceBenefit, CancellationToken ct = default);
    Task RemoveAsync(AudienceBenefit audienceBenefit, CancellationToken ct = default);
    Task<IReadOnlyList<AudienceBenefit>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
