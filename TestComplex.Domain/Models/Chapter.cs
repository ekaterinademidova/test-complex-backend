using System.Collections.Generic;

namespace TestComplex.Domain.Models
{
    public class Chapter
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Topic> Topics { get; set; }
    }
}
