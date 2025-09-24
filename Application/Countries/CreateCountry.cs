using MediatR;

namespace Application.Countries
{
    public class CreateCountry : IRequest<int>
    {
    public string? Name { get; set; }
    public string? IsoCode { get; set; }
    public string? AlfaSoftTwo { get; set; }
    public string? AlfaSofThree { get; set; }
    }
}
