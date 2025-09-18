using System.Collections.Generic;

namespace Domain.Entities
{
    public class CategoryPoll
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Poll> Polls { get; set; } = new HashSet<Poll>();
    }
}