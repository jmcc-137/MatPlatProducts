using MediatR;

namespace Application.Periods;

public sealed record CreatePeriod(string Name) : IRequest<int>;
