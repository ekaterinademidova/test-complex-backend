using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.QuestionsAdmin
{
    [Service]
    public class GetQuestion
    {

        private readonly IQuestionManager _questionManager;

        public GetQuestion(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        public QuestionViewModel Do(int id) =>
            _questionManager.GetQuestionById(id, x => new QuestionViewModel
            {
                Id = x.Id,
                Title = x.Title,
                TopicId = x.TopicId
            });

        public class QuestionViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public long TopicId { get; set; }
        }
    }
}
