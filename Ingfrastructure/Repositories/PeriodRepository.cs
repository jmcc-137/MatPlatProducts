using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using Ingfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ingfrastructure.Repositories;

public class PeriodRepository : IPeriodRepository
{
    private readonly AppDbContext _context;

    public PeriodRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Period?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.Periods
            .Include(p => p.MembershipPeriods)
            .FirstOrDefaultAsync(p => p.Id == id, ct);
    }

    public async Task<IReadOnlyList<Period>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.Periods
            .Include(p => p.MembershipPeriods)
            .ToListAsync(ct);
    }

    public async Task AddAsync(Period period, CancellationToken ct = default)
    {
        await _context.Periods.AddAsync(period, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Period period, CancellationToken ct = default)
    {
        _context.Periods.Update(period);
        await _context.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(Period period, CancellationToken ct = default)
    {
        _context.Periods.Remove(period);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<Period>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = _context.Periods
            .Include(p => p.MembershipPeriods)
            .AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p => p.Name.Contains(search));
        }
        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = _context.Periods.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p => p.Name.Contains(search));
        }
        return await query.CountAsync(ct);
    }
}
