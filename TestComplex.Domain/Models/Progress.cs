using System;

namespace TestComplex.Domain.Models
{
    public class Progress
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long TopicId { get; set; }
        public Topic Topic { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TestTime { get; set; }
        public double Mark { get; set; }
    }
}
