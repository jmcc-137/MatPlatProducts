using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using Ingfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ingfrastructure.Repositories;

public class StateRegionRepository : IStateRegionRepository
{
    private readonly AppDbContext _context;

    public StateRegionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<StateRegion?> GetByCodeAsync(string code, CancellationToken ct = default)
    {
        return await _context.StateRegions
            .Include(s => s.Country)
            .Include(s => s.CitiesOrMunicipalities)
            .FirstOrDefaultAsync(s => s.Code == code, ct);
    }

    public async Task<IReadOnlyList<StateRegion>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.StateRegions
            .Include(s => s.Country)
            .Include(s => s.CitiesOrMunicipalities)
            .ToListAsync(ct);
    }

    public async Task AddAsync(StateRegion stateRegion, CancellationToken ct = default)
    {
        await _context.StateRegions.AddAsync(stateRegion, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(StateRegion stateRegion, CancellationToken ct = default)
    {
        _context.StateRegions.Update(stateRegion);
        await _context.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(StateRegion stateRegion, CancellationToken ct = default)
    {
        _context.StateRegions.Remove(stateRegion);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<StateRegion>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = _context.StateRegions
            .Include(s => s.Country)
            .Include(s => s.CitiesOrMunicipalities)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(s => s.Name.Contains(search) || s.Code.Contains(search));
        }

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = _context.StateRegions.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(s => s.Name.Contains(search) || s.Code.Contains(search));
        }
        return await query.CountAsync(ct);
    }
}
