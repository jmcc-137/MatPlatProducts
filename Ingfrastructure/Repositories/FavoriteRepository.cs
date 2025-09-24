using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using Ingfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ingfrastructure.Repositories;

public class FavoriteRepository : IFavoriteRepository
{
    private readonly AppDbContext _context;

    public FavoriteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Favorite?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.Favorites
            .Include(f => f.Customer)
            .Include(f => f.Company)
            .Include(f => f.DetailFavorites)
            .FirstOrDefaultAsync(f => f.Id == id, ct);
    }

    public async Task<IReadOnlyList<Favorite>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.Favorites
            .Include(f => f.Customer)
            .Include(f => f.Company)
            .Include(f => f.DetailFavorites)
            .ToListAsync(ct);
    }

    public async Task AddAsync(Favorite favorite, CancellationToken ct = default)
    {
        await _context.Favorites.AddAsync(favorite, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Favorite favorite, CancellationToken ct = default)
    {
        _context.Favorites.Update(favorite);
        await _context.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(Favorite favorite, CancellationToken ct = default)
    {
        _context.Favorites.Remove(favorite);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<Favorite>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = _context.Favorites
            .Include(f => f.Customer)
            .Include(f => f.Company)
            .Include(f => f.DetailFavorites)
            .AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(f => f.CompanyId.Contains(search) || f.CustomerId.ToString().Contains(search));
        }
        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = _context.Favorites.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(f => f.CompanyId.Contains(search) || f.CustomerId.ToString().Contains(search));
        }
        return await query.CountAsync(ct);
    }
}
