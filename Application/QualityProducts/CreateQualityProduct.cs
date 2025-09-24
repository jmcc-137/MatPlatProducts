using MediatR;
using System;

namespace Application.QualityProducts;

public sealed record CreateQualityProduct(int ProductId, int CustomerId, int PollId, string CompanyId, DateTime DataRating, double Rating) : IRequest<(int ProductId, int CustomerId, int PollId, string CompanyId)>;
