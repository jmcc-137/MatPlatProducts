using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
// ...existing code...

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using Ingfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ingfrastructure.Repositories;

public class CityOrMunicipalityRepository : ICityOrMunicipalityRepository
{
    private readonly AppDbContext _context;

    public CityOrMunicipalityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CityOrMunicipality?> GetByCodeAsync(string code, CancellationToken ct = default)
    {
        return await _context.CitiesOrMunicipalities
            .Include(c => c.StateRegion)
            .FirstOrDefaultAsync(c => c.Code == code, ct);
    }

    public async Task<IReadOnlyList<CityOrMunicipality>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.CitiesOrMunicipalities
            .Include(c => c.StateRegion)
            .ToListAsync(ct);
    }

    public async Task AddAsync(CityOrMunicipality city, CancellationToken ct = default)
    {
        await _context.CitiesOrMunicipalities.AddAsync(city, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(CityOrMunicipality city, CancellationToken ct = default)
    {
        _context.CitiesOrMunicipalities.Update(city);
        await _context.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(CityOrMunicipality city, CancellationToken ct = default)
    {
        _context.CitiesOrMunicipalities.Remove(city);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<CityOrMunicipality>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = _context.CitiesOrMunicipalities
            .Include(c => c.StateRegion)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(c => c.Name.Contains(search) || c.Code.Contains(search));
        }

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = _context.CitiesOrMunicipalities.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(c => c.Name.Contains(search) || c.Code.Contains(search));
        }
        return await query.CountAsync(ct);
    }
}
