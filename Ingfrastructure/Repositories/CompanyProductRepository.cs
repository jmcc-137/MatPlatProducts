using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ingfrastructure.Persistence;
using Application.Abstractions;

namespace Ingfrastructure.Repositories;

public sealed class CompanyProductRepository(AppDbContext db) : ICompanyProductRepository
{
    public async Task<CompanyProduct?> GetByIdsAsync(string companyId, int productId, CancellationToken ct = default)
        => await db.CompanyProducts.AsNoTracking().FirstOrDefaultAsync(cp => cp.CompanyId == companyId && cp.ProductId == productId, ct);

    public async Task AddAsync(CompanyProduct companyProduct, CancellationToken ct = default)
    {
        db.CompanyProducts.Add(companyProduct);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(CompanyProduct companyProduct, CancellationToken ct = default)
    {
        db.CompanyProducts.Update(companyProduct);
        await db.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(CompanyProduct companyProduct, CancellationToken ct = default)
    {
        db.CompanyProducts.Remove(companyProduct);
        await db.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<CompanyProduct>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = db.CompanyProducts.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(cp => cp.CompanyId.ToUpper().Contains(term));
        }
        return await query
            .OrderByDescending(cp => cp.CompanyId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = db.CompanyProducts.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(cp => cp.CompanyId.ToUpper().Contains(term));
        }
        return query.CountAsync(ct);
    }

    public async Task<IReadOnlyList<CompanyProduct>> GetAllAsync(CancellationToken ct = default)
    {
        return await db.CompanyProducts
            .AsNoTracking()
            .OrderByDescending(cp => cp.CompanyId)
            .ToListAsync(ct);
    }
}
