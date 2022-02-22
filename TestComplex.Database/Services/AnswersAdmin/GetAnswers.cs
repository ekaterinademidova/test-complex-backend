using System.Collections.Generic;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.AnswersAdmin
{
    [Service]
    public class GetAnswers
    {
        private readonly IAnswerManager _answerManager;

        public GetAnswers(IAnswerManager answerManager)
        {
            _answerManager = answerManager;
        }

        public IEnumerable<AnswerViewModel> Do() =>
            _answerManager.GetAnswers(x => new AnswerViewModel
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
