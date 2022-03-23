using System.Collections.Generic;
using System.Linq;
using TestComplex.Domain.Infrastucture;
using TestComplex.Domain.Models;

namespace TestComplex.Database.Services.Topics
{
    public class GetTopics
    {
        private readonly ITopicManager _topicManager;

        public GetTopics(ITopicManager topicManager)
        {
            _topicManager = topicManager;
        }

        public IEnumerable<TopicViewModel> Do(int chapterId) 
        {
            if (chapterId == 0)
            {
                return _topicManager.GetTopicsAll(x => new TopicViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    ChapterId = x.ChapterId,
                    Lecture = x.Lecture,
                    Lab = x.Lab,

                    QuestionsCount = x.Questions.Count
                }); ;
            }
            return _topicManager.GetTopicsInChapter(chapterId, x => new TopicViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ChapterId = x.ChapterId,
                Lecture = x.Lecture,
                Lab = x.Lab,

                QuestionsCount = x.Questions.Count
            }); ;
        }

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
