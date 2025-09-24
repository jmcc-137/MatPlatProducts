using MediatR;

namespace Application.Memberships;

public sealed record CreateMembership(string Name, string Description) : IRequest<int>;
