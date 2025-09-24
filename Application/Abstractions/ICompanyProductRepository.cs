using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface ICompanyProductRepository
{
    Task<CompanyProduct?> GetByIdsAsync(string companyId, int productId, CancellationToken ct = default);
    Task<IReadOnlyList<CompanyProduct>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(CompanyProduct companyProduct, CancellationToken ct = default);
    Task UpdateAsync(CompanyProduct companyProduct, CancellationToken ct = default);
    Task RemoveAsync(CompanyProduct companyProduct, CancellationToken ct = default);
    Task<IReadOnlyList<CompanyProduct>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
