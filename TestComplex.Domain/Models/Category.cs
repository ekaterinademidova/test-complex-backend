using System.Collections.Generic;

namespace TestComplex.Domain.Models
{
    public class Category
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Chapter> Chapters { get; set; }
    }
}
