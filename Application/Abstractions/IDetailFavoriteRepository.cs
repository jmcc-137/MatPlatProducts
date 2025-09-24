using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface IDetailFavoriteRepository
{
    Task<DetailFavorite?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<DetailFavorite>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(DetailFavorite detailFavorite, CancellationToken ct = default);
    Task UpdateAsync(DetailFavorite detailFavorite, CancellationToken ct = default);
    Task RemoveAsync(DetailFavorite detailFavorite, CancellationToken ct = default);
    Task<IReadOnlyList<DetailFavorite>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
