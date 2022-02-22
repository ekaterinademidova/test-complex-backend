using System.Collections.Generic;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Topics
{
    [Service]
    public class GetTopics
    {
        private readonly ITopicManager _topicManager;

        public GetTopics(ITopicManager topicManager)
        {
            _topicManager = topicManager;
        }

        public IEnumerable<TopicViewModel> Do() =>
            _topicManager.GetTopicsQuestions(x => new TopicViewModel
            {
                Title = x.Title,
                Description = x.Description,
                ChapterId = x.ChapterId,
                Lecture = x.Lecture,
                Lab = x.Lab,

                QuestionsCount = x.Questions.Count
            });


        public class TopicViewModel
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public long ChapterId { get; set; }
            public string Lecture { get; set; }
            public string Lab { get; set; }
            public int QuestionsCount { get; set; }
        }
    }
}