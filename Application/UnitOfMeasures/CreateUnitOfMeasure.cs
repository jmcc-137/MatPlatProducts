using MediatR;

namespace Application.UnitOfMeasures;

public sealed record CreateUnitOfMeasure(string Description) : IRequest<int>;
