namespace TestComplex.Domain.Models
{
    public class Answer
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public long QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
