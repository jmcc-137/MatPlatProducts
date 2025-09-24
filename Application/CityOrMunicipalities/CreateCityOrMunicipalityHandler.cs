using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.CityOrMunicipalities;

public sealed class CreateCityOrMunicipalityHandler(ICityOrMunicipalityRepository repo) : IRequestHandler<CreateCityOrMunicipality, string>
{
    public async Task<string> Handle(CreateCityOrMunicipality req, CancellationToken ct)
    {
        var city = new CityOrMunicipality { Code = req.Code, Name = req.Name, StateRegId = req.StateRegId };
        await repo.AddAsync(city, ct);
        return city.Code;
    }
}
