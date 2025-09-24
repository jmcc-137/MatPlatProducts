using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions;

public interface ITypeIdentificationRepository
{
    Task<TypeIdentification?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<TypeIdentification>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(TypeIdentification typeIdentification, CancellationToken ct = default);
    Task UpdateAsync(TypeIdentification typeIdentification, CancellationToken ct = default);
    Task RemoveAsync(TypeIdentification typeIdentification, CancellationToken ct = default);
    Task<IReadOnlyList<TypeIdentification>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
