using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using Ingfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ingfrastructure.Repositories;

public class UnitOfMeasureRepository : IUnitOfMeasureRepository
{
    private readonly AppDbContext _context;

    public UnitOfMeasureRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UnitOfMeasure?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.UnitOfMeasures
            .Include(u => u.CompanyProducts)
            .FirstOrDefaultAsync(u => u.Id == id, ct);
    }

    public async Task<IReadOnlyList<UnitOfMeasure>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.UnitOfMeasures
            .Include(u => u.CompanyProducts)
            .ToListAsync(ct);
    }

    public async Task AddAsync(UnitOfMeasure unit, CancellationToken ct = default)
    {
        await _context.UnitOfMeasures.AddAsync(unit, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(UnitOfMeasure unit, CancellationToken ct = default)
    {
        _context.UnitOfMeasures.Update(unit);
        await _context.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(UnitOfMeasure unit, CancellationToken ct = default)
    {
        _context.UnitOfMeasures.Remove(unit);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<UnitOfMeasure>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = _context.UnitOfMeasures
            .Include(u => u.CompanyProducts)
            .AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(u => u.Description.Contains(search));
        }
        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = _context.UnitOfMeasures.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(u => u.Description.Contains(search));
        }
        return await query.CountAsync(ct);
    }
}
