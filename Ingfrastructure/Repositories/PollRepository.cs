using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ingfrastructure.Persistence;
using Application.Abstractions;

namespace Ingfrastructure.Repositories;

public sealed class PollRepository(AppDbContext db) : IPollRepository
{
    public Task<Poll?> GetByIdAsync(int id, CancellationToken ct = default)
        => db.Polls.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, ct);

    public async Task AddAsync(Poll poll, CancellationToken ct = default)
    {
        db.Polls.Add(poll);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Poll poll, CancellationToken ct = default)
    {
        db.Polls.Update(poll);
        await db.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(Poll poll, CancellationToken ct = default)
    {
        db.Polls.Remove(poll);
        await db.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<Poll>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = db.Polls.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(p => p.Name.ToUpper().Contains(term) || p.Description.ToUpper().Contains(term));
        }
        return await query
            .OrderByDescending(p => p.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = db.Polls.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(p => p.Name.ToUpper().Contains(term) || p.Description.ToUpper().Contains(term));
        }
        return query.CountAsync(ct);
    }

    public async Task<IReadOnlyList<Poll>> GetAllAsync(CancellationToken ct = default)
    {
        return await db.Polls
            .AsNoTracking()
            .OrderByDescending(p => p.Id)
            .ToListAsync(ct);
    }
}
