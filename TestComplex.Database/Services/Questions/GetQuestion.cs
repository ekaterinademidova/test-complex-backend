using System.Collections.Generic;
using System.Linq;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Questions
{
    [Service]
    public class GetQuestion
    {
        private readonly IQuestionManager _questionManager;

        public GetQuestion(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        public QuestionViewModel Do(long id)
        {
            return _questionManager
                .GetQuestionById(id, x => new QuestionViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    TopicId = x.TopicId,

                    Answers = x.Answers.Select(y => new AnswerViewModel
                    {
                        Id = y.Id,
                        Title = y.Title,
                        Status = y.Status
                    })
                });
        }

        public class QuestionViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public long TopicId { get; set; }
            public IEnumerable<AnswerViewModel> Answers { get; set; }
        }

        public class AnswerViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public bool Status { get; set; }
        }
    }
}
