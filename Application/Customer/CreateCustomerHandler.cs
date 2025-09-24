using Domain.Entities;
using Application.Abstractions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomer, int>
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateCustomer request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Customer
            {
                Name = request.Name,
                Email = request.Email,
                Cellphone = request.Phone,
                AudienceId = request.AudienceId,
                CityId = request.CityId,
                Address = request.Address
            };
            await _repository.AddAsync(entity, cancellationToken);
            return entity.Id;
        }
    }
}
