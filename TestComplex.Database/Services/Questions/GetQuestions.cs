using System.Collections.Generic;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Questions
{
    [Service]
    public class GetQuestions
    {
        private readonly IQuestionManager _questionManager;

        public GetQuestions(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        public IEnumerable<QuestionViewModel> Do() =>
            _questionManager.GetQuestionsAnswers(x => new QuestionViewModel
            {
                Id = x.Id,
                Title = x.Title,
                TopicId = x.TopicId,

                AnswersCount = x.Answers.Count
            });

        public class QuestionViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public long TopicId { get; set; }

            public int AnswersCount { get; set; }

        }
    }
}
