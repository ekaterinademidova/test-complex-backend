using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.TopicsAdmin
{
    [Service]
    public class UpdateTopic
    {
        private readonly ITopicManager _topicManager;

        public UpdateTopic(ITopicManager topicManager)
        {
            _topicManager = topicManager;
        }

        public async Task<Response> Do(Request request)
        {
            var topic = _topicManager.GetTopicById(request.Id, x => x);

            topic.Title = request.Title;
            topic.Description = request.Description;
            topic.ChapterId = request.ChapterId;
            topic.Lecture = request.Lecture;
            topic.Lab = request.Lab;

            await _topicManager.UpdateTopic(topic);

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
            public long Id { get; set; }
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
