using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface ICompanyRepository
{
    Task<Company?> GetByIdAsync(string id, CancellationToken ct = default);
    Task<IReadOnlyList<Company>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(Company company, CancellationToken ct = default);
    Task UpdateAsync(Company company, CancellationToken ct = default);
    Task RemoveAsync(Company company, CancellationToken ct = default);
    Task<IReadOnlyList<Company>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
