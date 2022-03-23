using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Questions
{
    public class UpdateQuestion
    {
        private readonly IQuestionManager _questionManager;

        public UpdateQuestion(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        public async Task<Response> Do(Request request)
        {
            var question = _questionManager.GetQuestionById(request.Id, x => x);

            question.Title = request.Title;
            question.TopicId = request.TopicId;

            await _questionManager.UpdateQuestion(question);

            return new Response
            {
                Id = question.Id,
                Title = question.Title,
                TopicId = question.TopicId
            };
        }

        public class Request
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public long TopicId { get; set; }
        }

        public class Response
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public long TopicId { get; set; }
        }
    }
}
