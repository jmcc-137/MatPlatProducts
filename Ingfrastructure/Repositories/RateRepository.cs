
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ingfrastructure.Persistence;
using Application.Abstractions;

namespace Ingfrastructure.Repositories;

public sealed class RateRepository(AppDbContext db) : IRateRepository
{
    public async Task<Rate?> GetByIdsAsync(int customerId, string companyId, int pollId, CancellationToken ct = default)
        => await db.Rates.AsNoTracking().FirstOrDefaultAsync(r => r.CustomerId == customerId && r.CompanyId == companyId && r.PollId == pollId, ct);

    public async Task AddAsync(Rate rate, CancellationToken ct = default)
    {
        db.Rates.Add(rate);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Rate rate, CancellationToken ct = default)
    {
        db.Rates.Update(rate);
        await db.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(Rate rate, CancellationToken ct = default)
    {
        db.Rates.Remove(rate);
        await db.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<Rate>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = db.Rates.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(r => r.CompanyId.ToUpper().Contains(term));
        }
        return await query
            .OrderByDescending(r => r.DataRating)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = db.Rates.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(r => r.CompanyId.ToUpper().Contains(term));
        }
        return query.CountAsync(ct);
    }

    public async Task<IReadOnlyList<Rate>> GetAllAsync(CancellationToken ct = default)
    {
        return await db.Rates
            .AsNoTracking()
            .OrderByDescending(r => r.DataRating)
            .ToListAsync(ct);
    }
}
