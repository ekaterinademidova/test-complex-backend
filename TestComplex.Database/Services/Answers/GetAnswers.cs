using System.Collections.Generic;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Answers
{
    public class GetAnswers
    {
        private readonly IAnswerManager _answerManager;

        public GetAnswers(IAnswerManager answerManager)
        {
            _answerManager = answerManager;
        }

        public IEnumerable<AnswerViewModel> Do(int questionId) =>
            _answerManager.GetAnswers(questionId, x => new AnswerViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Status = x.Status,
                QuestionId = x.QuestionId
            });

        public class AnswerViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public bool Status { get; set; }
            public long QuestionId { get; set; }
        }
    }
}
