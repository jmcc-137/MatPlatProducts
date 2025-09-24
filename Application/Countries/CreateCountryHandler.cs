using Domain.Entities;
using Application.Abstractions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Countries
{
    public class CreateCountryHandler : IRequestHandler<CreateCountry, int>
    {
        private readonly ICountryRepository _repository;

        public CreateCountryHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateCountry request, CancellationToken cancellationToken)
        {
            var entity = new Country
            {
                Name = request.Name ?? string.Empty,
                IsoCode = request.IsoCode ?? string.Empty,
                AlfaSoftTwo = request.AlfaSoftTwo ?? string.Empty,
                AlfaSofThree = request.AlfaSofThree ?? string.Empty
            };
            await _repository.AddAsync(entity, cancellationToken);
            return 1; // Ajustar según la lógica de persistencia
        }
    }
}
