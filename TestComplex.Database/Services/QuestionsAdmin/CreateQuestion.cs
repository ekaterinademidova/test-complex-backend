using System;
using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;
using TestComplex.Domain.Models;

namespace TestComplex.Database.Services.QuestionsAdmin
{
    [Service]
    public class CreateQuestion
    {
        private readonly IQuestionManager _questionManager;

        public CreateQuestion(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        public async Task<Response> Do(Request request)
        {
            var question = new Question
            {
                Title = request.Title,
                TopicId = request.TopicId
            };

            if (await _questionManager.CreateQuestion(question) <= 0)
            {
                throw new Exception("Failed to create question");
            }

            return new Response
            {
                Id = question.Id,
                Title = question.Title,
                TopicId = question.TopicId
            };
        }

        public class Request
        {
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
