using MediatR;

namespace Application.CategoryPolls;

public sealed record CreateCategoryPoll(string Name) : IRequest<int>;
