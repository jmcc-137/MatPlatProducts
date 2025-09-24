
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ingfrastructure.Persistence;
using Application.Abstractions;

namespace Ingfrastructure.Repositories;

public sealed class QualityProductRepository(AppDbContext db) : IQualityProductRepository
{
    public async Task<QualityProduct?> GetByIdsAsync(int productId, int customerId, int pollId, string companyId, CancellationToken ct = default)
        => await db.QualityProducts.AsNoTracking().FirstOrDefaultAsync(q => q.ProductId == productId && q.CustomerId == customerId && q.PollId == pollId && q.CompanyId == companyId, ct);

    public async Task AddAsync(QualityProduct qualityProduct, CancellationToken ct = default)
    {
        db.QualityProducts.Add(qualityProduct);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(QualityProduct qualityProduct, CancellationToken ct = default)
    {
        db.QualityProducts.Update(qualityProduct);
        await db.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(QualityProduct qualityProduct, CancellationToken ct = default)
    {
        db.QualityProducts.Remove(qualityProduct);
        await db.SaveChangesAsync(ct);
    }


    public async Task<IReadOnlyList<QualityProduct>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = db.QualityProducts.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(q => q.CompanyId.ToUpper().Contains(term));
        }
        return await query
            .OrderByDescending(q => q.DataRating)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = db.QualityProducts.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(q => q.CompanyId.ToUpper().Contains(term));
        }
        return query.CountAsync(ct);
    }

    public async Task<IReadOnlyList<QualityProduct>> GetAllAsync(CancellationToken ct = default)
    {
        return await db.QualityProducts
            .AsNoTracking()
            .OrderByDescending(q => q.DataRating)
            .ToListAsync(ct);
    }
}
