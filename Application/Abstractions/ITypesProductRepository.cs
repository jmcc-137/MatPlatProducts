using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface ITypesProductRepository
{
    Task<TypesProduct?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<TypesProduct>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(TypesProduct typesProduct, CancellationToken ct = default);
    Task UpdateAsync(TypesProduct typesProduct, CancellationToken ct = default);
    Task RemoveAsync(TypesProduct typesProduct, CancellationToken ct = default);
    Task<IReadOnlyList<TypesProduct>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
