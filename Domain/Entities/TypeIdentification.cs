namespace Domain.Entities
{
    public class TypeIdentification
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;
    }
}