using MediatR;

namespace Application.CityOrMunicipalities;

public sealed record CreateCityOrMunicipality(string Code, string Name, string StateRegId) : IRequest<string>;
