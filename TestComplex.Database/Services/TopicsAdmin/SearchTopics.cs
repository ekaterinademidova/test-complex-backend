using System.Collections.Generic;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.TopicsAdmin
{
    [Service]
    public class SearchTopics
    {
        private readonly ITopicManager _topicManager;

        public SearchTopics(ITopicManager topicManager)
        {
            _topicManager = topicManager;
        }

        public IEnumerable<TopicViewModel> Do(string topicName)
        {
            if (topicName == null)
            {
                return _topicManager.GetTopicsQuestions(x => new TopicViewModel
                {
                    Title = x.Title,
                    Description = x.Description,
                    ChapterId = x.ChapterId,
                    Lecture = x.Lecture,
                    Lab = x.Lab
                });
            }
            else
            {
                return _topicManager.SearchTopics(topicName, x => new TopicViewModel
                {
                    Title = x.Title,
                    Description = x.Description,
                    ChapterId = x.ChapterId,
                    Lecture = x.Lecture,
                    Lab = x.Lab
                });
            }
                
        }
            

        public class TopicViewModel
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
