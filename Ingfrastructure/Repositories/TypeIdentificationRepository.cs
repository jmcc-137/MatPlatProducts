using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using Ingfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ingfrastructure.Repositories;

public class TypeIdentificationRepository : ITypeIdentificationRepository
{
    private readonly AppDbContext _context;

    public TypeIdentificationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TypeIdentification?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.TypeIdentifications.FirstOrDefaultAsync(t => t.Id == id, ct);
    }

    public async Task<IReadOnlyList<TypeIdentification>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.TypeIdentifications.ToListAsync(ct);
    }

    public async Task AddAsync(TypeIdentification typeIdentification, CancellationToken ct = default)
    {
        await _context.TypeIdentifications.AddAsync(typeIdentification, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(TypeIdentification typeIdentification, CancellationToken ct = default)
    {
        _context.TypeIdentifications.Update(typeIdentification);
        await _context.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(TypeIdentification typeIdentification, CancellationToken ct = default)
    {
        _context.TypeIdentifications.Remove(typeIdentification);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<TypeIdentification>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = _context.TypeIdentifications.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(t => t.Description.Contains(search) || t.Suffix.Contains(search));
        }
        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = _context.TypeIdentifications.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(t => t.Description.Contains(search) || t.Suffix.Contains(search));
        }
        return await query.CountAsync(ct);
    }
}
