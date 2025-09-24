
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using Ingfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ingfrastructure.Repositories;

public class MembershipBenefitRepository : IMembershipBenefitRepository
{
    private readonly AppDbContext _context;

    public MembershipBenefitRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MembershipBenefit?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.MembershipBenefits
            .Include(mb => mb.MembershipPeriod)
            .Include(mb => mb.Benefit)
            .FirstOrDefaultAsync(mb => mb.Id == id, ct);
    }

    public async Task<IReadOnlyList<MembershipBenefit>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.MembershipBenefits
            .Include(mb => mb.MembershipPeriod)
            .Include(mb => mb.Benefit)
            .ToListAsync(ct);
    }

    public async Task AddAsync(MembershipBenefit benefit, CancellationToken ct = default)
    {
        await _context.MembershipBenefits.AddAsync(benefit, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(MembershipBenefit benefit, CancellationToken ct = default)
    {
        _context.MembershipBenefits.Update(benefit);
        await _context.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(MembershipBenefit benefit, CancellationToken ct = default)
    {
        _context.MembershipBenefits.Remove(benefit);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<MembershipBenefit>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = _context.MembershipBenefits
            .Include(mb => mb.MembershipPeriod)
            .Include(mb => mb.Benefit)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(mb =>
                (mb.MembershipPeriod.Name != null && mb.MembershipPeriod.Name.Contains(search)) ||
                (mb.Benefit != null && mb.Benefit.Description != null && mb.Benefit.Description.Contains(search))
            );
        }

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = _context.MembershipBenefits.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(mb =>
                (mb.MembershipPeriod.Name != null && mb.MembershipPeriod.Name.Contains(search)) ||
                (mb.Benefit != null && mb.Benefit.Description != null && mb.Benefit.Description.Contains(search))
            );
        }

        return await query.CountAsync(ct);
    }
}
