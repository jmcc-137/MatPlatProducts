using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Companies;

public sealed class CreateCompanyHandler(ICompanyRepository repo) : IRequestHandler<CreateCompany, string>
{
    public async Task<string> Handle(CreateCompany req, CancellationToken ct)
    {
        var company = new Company
        {
            Id = req.Id,
            TypeId = req.TypeId,
            Name = req.Name,
            CategoryId = req.CategoryId,
            CityId = req.CityId,
            AudienceId = req.AudienceId,
            Cellphone = req.Cellphone,
            Email = req.Email
        };
        await repo.AddAsync(company, ct);
        return company.Id;
    }
}
