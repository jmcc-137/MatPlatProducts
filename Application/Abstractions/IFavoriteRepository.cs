using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface IFavoriteRepository
{
    Task<Favorite?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<Favorite>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(Favorite favorite, CancellationToken ct = default);
    Task UpdateAsync(Favorite favorite, CancellationToken ct = default);
    Task RemoveAsync(Favorite favorite, CancellationToken ct = default);
    Task<IReadOnlyList<Favorite>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
