using System.Collections.Generic;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.QuestionsAdmin
{
    [Service]
    public class SearchQuestions
    {
        private readonly IQuestionManager _questionManager;

        public SearchQuestions(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        public IEnumerable<QuestionViewModel> Do(string questionName)
        {
            if (questionName == null)
            {
                return _questionManager.GetQuestionsAnswers(x => new QuestionViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    TopicId = x.TopicId
                });
            }
            else
            {
                return _questionManager.SearchQuestions(questionName, x => new QuestionViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    TopicId = x.TopicId
                });
            }
                
        }

        public class QuestionViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public long TopicId { get; set; }
        }
    }
}
