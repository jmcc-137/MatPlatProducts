using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Abstractions;
using Ingfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ingfrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;

        public CountryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Country?> GetByIdAsync(string isoCode, CancellationToken ct = default)
        {
            return await _context.Set<Country>().FirstOrDefaultAsync(c => c.IsoCode == isoCode, ct);
        }

        public async Task<IReadOnlyList<Country>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.Set<Country>().ToListAsync(ct);
        }

        public async Task AddAsync(Country country, CancellationToken ct = default)
        {
            await _context.Set<Country>().AddAsync(country, ct);
            await _context.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Country country, CancellationToken ct = default)
        {
            _context.Set<Country>().Update(country);
            await _context.SaveChangesAsync(ct);
        }

        public async Task RemoveAsync(Country country, CancellationToken ct = default)
        {
            _context.Set<Country>().Remove(country);
            await _context.SaveChangesAsync(ct);
        }
    }
}
