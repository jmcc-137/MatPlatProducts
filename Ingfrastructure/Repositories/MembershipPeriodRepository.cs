using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using Ingfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ingfrastructure.Repositories;

public class MembershipPeriodRepository : IMembershipPeriodRepository
{
    private readonly AppDbContext _context;

    public MembershipPeriodRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MembershipPeriod?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.MembershipPeriods
            .Include(mp => mp.Membership)
            .Include(mp => mp.Period)
            .Include(mp => mp.Company)
            .Include(mp => mp.MembershipBenefits)
            .FirstOrDefaultAsync(mp => mp.Id == id, ct);
    }

    public async Task<IReadOnlyList<MembershipPeriod>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.MembershipPeriods
            .Include(mp => mp.Membership)
            .Include(mp => mp.Period)
            .Include(mp => mp.Company)
            .Include(mp => mp.MembershipBenefits)
            .ToListAsync(ct);
    }

    public async Task AddAsync(MembershipPeriod period, CancellationToken ct = default)
    {
        await _context.MembershipPeriods.AddAsync(period, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(MembershipPeriod period, CancellationToken ct = default)
    {
        _context.MembershipPeriods.Update(period);
        await _context.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(MembershipPeriod period, CancellationToken ct = default)
    {
        _context.MembershipPeriods.Remove(period);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<MembershipPeriod>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = _context.MembershipPeriods
            .Include(mp => mp.Membership)
            .Include(mp => mp.Period)
            .Include(mp => mp.Company)
            .Include(mp => mp.MembershipBenefits)
            .AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(mp => mp.Name.Contains(search) || mp.Description.Contains(search));
        }
        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = _context.MembershipPeriods.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(mp => mp.Name.Contains(search) || mp.Description.Contains(search));
        }
        return await query.CountAsync(ct);
    }
}
