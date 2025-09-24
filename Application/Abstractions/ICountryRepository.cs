using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions
{
    public interface ICountryRepository
    {
        Task<Country?> GetByIdAsync(string isoCode, CancellationToken ct = default);
        Task<IReadOnlyList<Country>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Country country, CancellationToken ct = default);
        Task UpdateAsync(Country country, CancellationToken ct = default);
        Task RemoveAsync(Country country, CancellationToken ct = default);
    }
}
