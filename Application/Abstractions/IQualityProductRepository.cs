using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface IQualityProductRepository
{
    Task<QualityProduct?> GetByIdsAsync(int productId, int customerId, int pollId, string companyId, CancellationToken ct = default);
    Task<IReadOnlyList<QualityProduct>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(QualityProduct qualityProduct, CancellationToken ct = default);
    Task UpdateAsync(QualityProduct qualityProduct, CancellationToken ct = default);
    Task RemoveAsync(QualityProduct qualityProduct, CancellationToken ct = default);
    Task<IReadOnlyList<QualityProduct>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
