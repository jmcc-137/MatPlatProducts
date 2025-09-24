using MediatR;

namespace Application.Audiences;

public sealed record CreateAudience(string Description) : IRequest<int>;
