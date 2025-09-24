using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface IStateRegionRepository
{
    Task<StateRegion?> GetByCodeAsync(string code, CancellationToken ct = default);
    Task<IReadOnlyList<StateRegion>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(StateRegion stateRegion, CancellationToken ct = default);
    Task UpdateAsync(StateRegion stateRegion, CancellationToken ct = default);
    Task RemoveAsync(StateRegion stateRegion, CancellationToken ct = default);
    Task<IReadOnlyList<StateRegion>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
