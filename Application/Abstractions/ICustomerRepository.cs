using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CustomerEntity = Domain.Entities.Customer;

namespace Application.Abstractions
{
    public interface ICustomerRepository
    {
    Task<CustomerEntity?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<CustomerEntity>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(CustomerEntity customer, CancellationToken ct = default);
    Task UpdateAsync(CustomerEntity customer, CancellationToken ct = default);
    Task RemoveAsync(CustomerEntity customer, CancellationToken ct = default);
    Task<IReadOnlyList<CustomerEntity>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}
