using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ingfrastructure.Persistence;
using Application.Abstractions;

namespace Ingfrastructure.Repositories;

public sealed class MembershipRepository(AppDbContext db) : IMembershipRepository
{
    public Task<Membership?> GetByIdAsync(int id, CancellationToken ct = default)
        => db.Memberships.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id, ct);

    public async Task AddAsync(Membership membership, CancellationToken ct = default)
    {
        db.Memberships.Add(membership);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Membership membership, CancellationToken ct = default)
    {
        db.Memberships.Update(membership);
        await db.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(Membership membership, CancellationToken ct = default)
    {
        db.Memberships.Remove(membership);
        await db.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<Membership>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = db.Memberships.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(m => m.Name.ToUpper().Contains(term) || m.Description.ToUpper().Contains(term));
        }
        return await query
            .OrderByDescending(m => m.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = db.Memberships.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(m => m.Name.ToUpper().Contains(term) || m.Description.ToUpper().Contains(term));
        }
        return query.CountAsync(ct);
    }

    public async Task<IReadOnlyList<Membership>> GetAllAsync(CancellationToken ct = default)
    {
        return await db.Memberships
            .AsNoTracking()
            .OrderByDescending(m => m.Id)
            .ToListAsync(ct);
    }
}
