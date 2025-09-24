
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ingfrastructure.Persistence;
using Application.Abstractions;

namespace Ingfrastructure.Repositories;

public sealed class CompanyRepository(AppDbContext db) : ICompanyRepository
{
    public Task<Company?> GetByIdAsync(string id, CancellationToken ct = default)
        => db.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, ct);

    public async Task AddAsync(Company company, CancellationToken ct = default)
    {
        db.Companies.Add(company);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Company company, CancellationToken ct = default)
    {
        db.Companies.Update(company);
        await db.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(Company company, CancellationToken ct = default)
    {
        db.Companies.Remove(company);
        await db.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<Company>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = db.Companies.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(c => c.Name.ToUpper().Contains(term));
        }
        return await query
            .OrderByDescending(c => c.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = db.Companies.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(c => c.Name.ToUpper().Contains(term));
        }
        return query.CountAsync(ct);
    }

    public async Task<IReadOnlyList<Company>> GetAllAsync(CancellationToken ct = default)
    {
        return await db.Companies
            .AsNoTracking()
            .OrderByDescending(c => c.Id)
            .ToListAsync(ct);
    }
}
