
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ingfrastructure.Persistence;
using Application.Abstractions;

namespace Ingfrastructure.Repositories;

public sealed class BenefitRepository(AppDbContext db) : IBenefitRepository
{
    public Task<Benefit?> GetByIdAsync(int id, CancellationToken ct = default)
        => db.Benefits.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id, ct);

    public async Task AddAsync(Benefit benefit, CancellationToken ct = default)
    {
        db.Benefits.Add(benefit);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Benefit benefit, CancellationToken ct = default)
    {
        db.Benefits.Update(benefit);
        await db.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(Benefit benefit, CancellationToken ct = default)
    {
        db.Benefits.Remove(benefit);
        await db.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<Benefit>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = db.Benefits.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(b => b.Description.ToUpper().Contains(term) || b.Detail.ToUpper().Contains(term));
        }
        return await query
            .OrderByDescending(b => b.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = db.Benefits.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(b => b.Description.ToUpper().Contains(term) || b.Detail.ToUpper().Contains(term));
        }
        return query.CountAsync(ct);
    }

    public async Task<IReadOnlyList<Benefit>> GetAllAsync(CancellationToken ct = default)
    {
        return await db.Benefits
            .AsNoTracking()
            .OrderByDescending(b => b.Id)
            .ToListAsync(ct);
    }
}
