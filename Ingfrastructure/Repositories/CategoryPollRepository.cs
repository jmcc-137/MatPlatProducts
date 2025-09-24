using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ingfrastructure.Persistence;
using Application.Abstractions;

namespace Ingfrastructure.Repositories;

public sealed class CategoryPollRepository(AppDbContext db) : ICategoryPollRepository
{
    public Task<CategoryPoll?> GetByIdAsync(int id, CancellationToken ct = default)
        => db.CategoryPolls.AsNoTracking().FirstOrDefaultAsync(cp => cp.Id == id, ct);

    public async Task AddAsync(CategoryPoll categoryPoll, CancellationToken ct = default)
    {
        db.CategoryPolls.Add(categoryPoll);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(CategoryPoll categoryPoll, CancellationToken ct = default)
    {
        db.CategoryPolls.Update(categoryPoll);
        await db.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(CategoryPoll categoryPoll, CancellationToken ct = default)
    {
        db.CategoryPolls.Remove(categoryPoll);
        await db.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<CategoryPoll>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = db.CategoryPolls.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(cp => cp.Name.ToUpper().Contains(term));
        }
        return await query
            .OrderByDescending(cp => cp.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = db.CategoryPolls.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(cp => cp.Name.ToUpper().Contains(term));
        }
        return query.CountAsync(ct);
    }

    public async Task<IReadOnlyList<CategoryPoll>> GetAllAsync(CancellationToken ct = default)
    {
        return await db.CategoryPolls
            .AsNoTracking()
            .OrderByDescending(cp => cp.Id)
            .ToListAsync(ct);
    }
}
