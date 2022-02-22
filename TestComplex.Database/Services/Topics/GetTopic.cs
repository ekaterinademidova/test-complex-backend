using System.Collections.Generic;
using System.Linq;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Topics
{
    [Service]
    public class GetTopic
    {
        private readonly ITopicManager _topicManager;

        public GetTopic(ITopicManager topicManager)
        {
            _topicManager = topicManager;
        }

        public TopicViewModel Do(long id)
        {
            return _topicManager
                .GetTopicById(id, x => new TopicViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    ChapterId = x.ChapterId,
                    Lecture = x.Lecture,
                    Lab = x.Lab,

                    Questions = x.Questions.Select(y => new QuestionViewModel
                    {
                        Id = y.Id,
                        Title = y.Title                        
                    })
                });
        }

        public class TopicViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public long ChapterId { get; set; }
            public string Lecture { get; set; }
            public string Lab { get; set; }
            public IEnumerable<QuestionViewModel> Questions { get; set; }
        }

        public class QuestionViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
        }
    }
}
