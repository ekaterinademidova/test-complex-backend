using System.Collections.Generic;

namespace TestComplex.Domain.Models
{
    public class Question
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long TopicId { get; set; }
        public Topic Topic { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
