using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface ICityOrMunicipalityRepository
{
    Task<CityOrMunicipality?> GetByCodeAsync(string code, CancellationToken ct = default);
    Task<IReadOnlyList<CityOrMunicipality>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(CityOrMunicipality city, CancellationToken ct = default);
    Task UpdateAsync(CityOrMunicipality city, CancellationToken ct = default);
    Task RemoveAsync(CityOrMunicipality city, CancellationToken ct = default);
    Task<IReadOnlyList<CityOrMunicipality>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
