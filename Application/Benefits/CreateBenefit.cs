using MediatR;

namespace Application.Benefits;

public sealed record CreateBenefit(string Description, string Detail) : IRequest<int>;
