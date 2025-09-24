using MediatR;

namespace Application.Companies;

public sealed record CreateCompany(
	string Id,
	int TypeId,
	string Name,
	int CategoryId,
	string CityId,
	int AudienceId,
	string Cellphone,
	string Email
) : IRequest<string>;
