
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ingfrastructure.Persistence;
using Application.Abstractions;

namespace Ingfrastructure.Repositories;

public sealed class AudienceBenefitRepository(AppDbContext db) : IAudienceBenefitRepository
{
    public async Task<AudienceBenefit?> GetByIdsAsync(int audienceId, int benefitId, CancellationToken ct = default)
        => await db.AudienceBenefits.AsNoTracking().FirstOrDefaultAsync(ab => ab.AudienceId == audienceId && ab.BenefitId == benefitId, ct);

    public async Task AddAsync(AudienceBenefit audienceBenefit, CancellationToken ct = default)
    {
        db.AudienceBenefits.Add(audienceBenefit);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(AudienceBenefit audienceBenefit, CancellationToken ct = default)
    {
        db.AudienceBenefits.Update(audienceBenefit);
        await db.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(AudienceBenefit audienceBenefit, CancellationToken ct = default)
    {
        db.AudienceBenefits.Remove(audienceBenefit);
        await db.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<AudienceBenefit>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = db.AudienceBenefits.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(ab => ab.AudienceId.ToString().Contains(term) || ab.BenefitId.ToString().Contains(term));
        }
        return await query
            .OrderByDescending(ab => ab.AudienceId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = db.AudienceBenefits.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(ab => ab.AudienceId.ToString().Contains(term) || ab.BenefitId.ToString().Contains(term));
        }
        return query.CountAsync(ct);
    }

    public async Task<IReadOnlyList<AudienceBenefit>> GetAllAsync(CancellationToken ct = default)
    {
        return await db.AudienceBenefits
            .AsNoTracking()
            .OrderByDescending(ab => ab.AudienceId)
            .ToListAsync(ct);
    }
}
