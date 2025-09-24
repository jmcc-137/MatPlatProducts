using MediatR;

namespace Application.AudienceBenefits;

public sealed record CreateAudienceBenefit(int AudienceId, int BenefitId) : IRequest<(int AudienceId, int BenefitId)>;
