using MediatR;

namespace Application.Customer
{
    public class CreateCustomer : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int AudienceId { get; set; }
        public string CityId { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
