using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using Ingfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ingfrastructure.Repositories;

public class TypesProductRepository : ITypesProductRepository
{
    private readonly AppDbContext _context;

    public TypesProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TypesProduct?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.TypesProducts
            .Include(tp => tp.Products)
            .FirstOrDefaultAsync(tp => tp.Id == id, ct);
    }

    public async Task<IReadOnlyList<TypesProduct>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.TypesProducts
            .Include(tp => tp.Products)
            .ToListAsync(ct);
    }

    public async Task AddAsync(TypesProduct typesProduct, CancellationToken ct = default)
    {
        await _context.TypesProducts.AddAsync(typesProduct, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(TypesProduct typesProduct, CancellationToken ct = default)
    {
        _context.TypesProducts.Update(typesProduct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(TypesProduct typesProduct, CancellationToken ct = default)
    {
        _context.TypesProducts.Remove(typesProduct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<TypesProduct>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = _context.TypesProducts
            .Include(tp => tp.Products)
            .AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(tp => tp.Description.Contains(search));
        }
        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = _context.TypesProducts.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(tp => tp.Description.Contains(search));
        }
        return await query.CountAsync(ct);
    }
}
