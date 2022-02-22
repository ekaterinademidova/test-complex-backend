using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Answers
{
    [Service]
    public class GetAnswer
    {

        private readonly IAnswerManager _answerManager;

        public GetAnswer(IAnswerManager answerManager)
        {
            _answerManager = answerManager;
        }

        public AnswerViewModel Do(int id)
        {
            return _answerManager.GetAnswerById(id, x => new AnswerViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Status = x.Status,
                QuestionId = x.QuestionId
            });
        }

        public class AnswerViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public bool Status { get; set; }
            public long QuestionId { get; set; }
        }
    }
}
