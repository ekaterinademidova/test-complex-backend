using System.Collections.Generic;

namespace TestComplex.Domain.Models
{
    public class Topic
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long ChapterId { get; set; }
        public Chapter Chapter { get; set; }
        public string Lecture { get; set; }
        public string Lab { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
