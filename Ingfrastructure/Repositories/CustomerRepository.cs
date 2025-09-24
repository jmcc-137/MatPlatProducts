
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ingfrastructure.Persistence;
using Application.Abstractions;

namespace Ingfrastructure.Repositories;

public sealed class CustomerRepository(AppDbContext db) : ICustomerRepository
{
    public Task<Customer?> GetByIdAsync(int id, CancellationToken ct = default)
        => db.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, ct);

    public async Task AddAsync(Customer customer, CancellationToken ct = default)
    {
        db.Customers.Add(customer);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Customer customer, CancellationToken ct = default)
    {
        db.Customers.Update(customer);
        await db.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(Customer customer, CancellationToken ct = default)
    {
        db.Customers.Remove(customer);
        await db.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<Customer>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = db.Customers.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(c => c.Name.ToUpper().Contains(term) || c.Email.ToUpper().Contains(term));
        }
        return await query
            .OrderByDescending(c => c.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = db.Customers.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(c => c.Name.ToUpper().Contains(term) || c.Email.ToUpper().Contains(term));
        }
        return query.CountAsync(ct);
    }

    public async Task<IReadOnlyList<Customer>> GetAllAsync(CancellationToken ct = default)
    {
        return await db.Customers
            .AsNoTracking()
            .OrderByDescending(c => c.Id)
            .ToListAsync(ct);
    }
}
