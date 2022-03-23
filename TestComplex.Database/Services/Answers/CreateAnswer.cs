using System;
using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;
using TestComplex.Domain.Models;

namespace TestComplex.Database.Services.Answers
{
    public class CreateAnswer
    {
        private readonly IAnswerManager _answerManager;

        public CreateAnswer(IAnswerManager answerManager)
        {
            _answerManager = answerManager;
        }

        public async Task<Response> Do(Request request)
        {
            var answer = new Answer
            {
                Title = request.Title,
                Status = request.Status,
                QuestionId = request.QuestionId
            };

            if (await _answerManager.CreateAnswer(answer) <= 0)
            {
                throw new Exception("Failed to create answer");
            }

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
