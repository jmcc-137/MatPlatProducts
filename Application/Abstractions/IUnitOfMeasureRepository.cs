using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface IUnitOfMeasureRepository
{
    Task<UnitOfMeasure?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<UnitOfMeasure>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(UnitOfMeasure unit, CancellationToken ct = default);
    Task UpdateAsync(UnitOfMeasure unit, CancellationToken ct = default);
    Task RemoveAsync(UnitOfMeasure unit, CancellationToken ct = default);
    Task<IReadOnlyList<UnitOfMeasure>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
