using MediatR;

namespace Application.MembershipPeriods;

public sealed record CreateMembershipPeriod(int MembershipId, int PeriodId, string Name, string Description, double Price, string CompanyId) : IRequest<int>;
