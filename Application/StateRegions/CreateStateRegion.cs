using MediatR;

namespace Application.StateRegions;

public sealed record CreateStateRegion(string Code, string Name, string CountryId, string Code3166, string StateRegId, int? SubdivisionId) : IRequest<string>;
