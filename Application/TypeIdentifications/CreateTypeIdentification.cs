using MediatR;

namespace Application.TypeIdentifications;

public sealed record CreateTypeIdentification(string Description, string Suffix) : IRequest<int>;
