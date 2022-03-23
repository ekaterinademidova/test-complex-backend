using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Answers
{
    public class UpdateAnswer
    {
        private readonly IAnswerManager _answerManager;

        public UpdateAnswer(IAnswerManager answerManager)
        {
            _answerManager = answerManager;
        }

        public async Task<Response> Do(Request request)
        {
            var answer = _answerManager.GetAnswerById(request.Id, x => x);

            answer.Title = request.Title;
            answer.Status = request.Status;
            answer.QuestionId = request.QuestionId;

            await _answerManager.UpdateAnswer(answer);

            return new Response
            {
                Id = answer.Id,
                Title = answer.Title,
                Status = answer.Status,
                QuestionId = answer.QuestionId
            };
        }

        public class Request
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public bool Status { get; set; }
            public long QuestionId { get; set; }
        }

        public class Response
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public bool Status { get; set; }
            public long QuestionId { get; set; }
        }
    }
}
