using MediatR;

namespace Application.CompanyProducts;

public sealed record CreateCompanyProduct(string CompanyId, int ProductId, double Price, int UnitMeasureId) : IRequest<(string CompanyId, int ProductId)>;
