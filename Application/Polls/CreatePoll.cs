using MediatR;

namespace Application.Polls;

public sealed record CreatePoll(string Name, string Description, bool IsActive, int CategoryPollId) : IRequest<int>;
