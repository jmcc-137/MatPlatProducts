using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using Ingfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ingfrastructure.Repositories;

public class DetailFavoriteRepository : IDetailFavoriteRepository
{
    private readonly AppDbContext _context;

    public DetailFavoriteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<DetailFavorite?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.DetailFavorites
            .Include(df => df.Favorite)
            .Include(df => df.Product)
            .FirstOrDefaultAsync(df => df.Id == id, ct);
    }

    public async Task<IReadOnlyList<DetailFavorite>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.DetailFavorites
            .Include(df => df.Favorite)
            .Include(df => df.Product)
            .ToListAsync(ct);
    }

    public async Task AddAsync(DetailFavorite detailFavorite, CancellationToken ct = default)
    {
        await _context.DetailFavorites.AddAsync(detailFavorite, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(DetailFavorite detailFavorite, CancellationToken ct = default)
    {
        _context.DetailFavorites.Update(detailFavorite);
        await _context.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(DetailFavorite detailFavorite, CancellationToken ct = default)
    {
        _context.DetailFavorites.Remove(detailFavorite);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<DetailFavorite>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = _context.DetailFavorites
            .Include(df => df.Favorite)
            .Include(df => df.Product)
            .AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(df => df.FavoriteId.ToString().Contains(search) || df.ProductId.ToString().Contains(search));
        }
        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = _context.DetailFavorites.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(df => df.FavoriteId.ToString().Contains(search) || df.ProductId.ToString().Contains(search));
        }
        return await query.CountAsync(ct);
    }
}
