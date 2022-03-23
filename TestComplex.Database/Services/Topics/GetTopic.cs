using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Topics
{
    public class GetTopic
    {
        private readonly ITopicManager _topicManager;

        public GetTopic(ITopicManager topicManager)
        {
            _topicManager = topicManager;
        }

        public TopicViewModel Do(int id) =>
            _topicManager.GetTopicById(id, x => new TopicViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ChapterId = x.ChapterId,
                Lecture = x.Lecture,
                Lab = x.Lab,

                QuestionsCount = x.Questions.Count
            });

        public class TopicViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public long ChapterId { get; set; }
            public string Lecture { get; set; }
            public string Lab { get; set; }

            public int QuestionsCount { get; set; }

        }
    }
}
