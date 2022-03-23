using System;
using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;
using TestComplex.Domain.Models;

namespace TestComplex.Database.Services.Topics
{
    public class CreateTopic
    {
        private readonly ITopicManager _topicManager;

        public CreateTopic(ITopicManager topicManager)
        {
            _topicManager = topicManager;
        }

        public async Task<Response> Do(Request request)
        {
            var topic = new Topic
            {
                Title = request.Title,
                Description = request.Description,
                ChapterId = request.ChapterId,
                Lecture = request.Lecture,
                Lab = request.Lab
        };

            if (await _topicManager.CreateTopic(topic) <= 0)
            {
                throw new Exception("Failed to create topic");
            }

            return new Response
            {
                Id = topic.Id,
                Title = topic.Title,
                Description = topic.Description,
                ChapterId = topic.ChapterId,
                Lecture = topic.Lecture,
                Lab = topic.Lab
            };
        }

        public class Request
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public long ChapterId { get; set; }
            public string Lecture { get; set; }
            public string Lab { get; set; }
        }

        public class Response
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public long ChapterId { get; set; }
            public string Lecture { get; set; }
            public string Lab { get; set; }
        }
    }
}
