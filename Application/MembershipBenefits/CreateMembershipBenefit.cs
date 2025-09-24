using MediatR;

namespace Application.MembershipBenefits;

public sealed record CreateMembershipBenefit(int MembershipPeriodId, int BenefitId) : IRequest<int>;
