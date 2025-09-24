using MediatR;
using System;

namespace Application.Rates;

public sealed record CreateRate(int CustomerId, string CompanyId, int PollId, DateTime DataRating, double Rating) : IRequest<(int CustomerId, string CompanyId, int PollId)>;
