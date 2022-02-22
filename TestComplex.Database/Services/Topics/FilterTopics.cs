using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestComplex.Domain.Enums;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Topics
{
    [Service]
    public class FilterTopics
    {
        //private ITopicManager _topicManager;

        //public FilterTopics(ITopicManager topicManager)
        //{
        //    _topicManager = topicManager;
        //}

        //public IEnumerable<TopicViewModel> Do(string topicName, Status status)
        //{
        //    if (topicName == null & status == Status.all)
        //    {
        //        return _topicManager.GetTopicsQuestions(x => new TopicViewModel
        //        {
        //            Title = x.Title,
        //            Description = x.Description,
        //            Status = x.Status,
        //            ChapterId = x.ChapterId,
        //            Lecture = x.Lecture,
        //            Lab = x.Lab
        //        });
        //    }
        //    else
        //    {
        //        return _topicManager.FilterTopics(topicName, status, x => new TopicViewModel
        //        {
        //            Title = x.Title,
        //            Description = x.Description,
        //            Status = x.Status,
        //            ChapterId = x.ChapterId,
        //            Lecture = x.Lecture,
        //            Lab = x.Lab
        //        });
        //    }

        //}


        //public class TopicViewModel
        //{
        //    public long Id { get; set; }
        //    public string Title { get; set; }
        //    public string Description { get; set; }
        //    public Status Status { get; set; }
        //    public long ChapterId { get; set; }
        //    public string Lecture { get; set; }
        //    public string Lab { get; set; }
        //}
    }
}
