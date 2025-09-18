using System.Collections.Generic;

namespace Domain.Entities
{
    public class Poll
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int CategoryPollId { get; set; }

        public CategoryPoll CategoryPoll { get; set; } = null!;
        public ICollection<QualityProduct> QualityProducts { get; set; } = new HashSet<QualityProduct>();
        public ICollection<Rate> Rates { get; set; } = new HashSet<Rate>();
    }
}