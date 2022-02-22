using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestComplex.Domain.Models;

namespace TestComplex.Domain.Infrastucture
{
    public interface ITopicManager
    {
        Task<int> CreateTopic(Topic topic);
        Task<int> DeleteTopic(long id);
        Task<int> UpdateTopic(Topic topic);

        TResult GetTopicById<TResult>(long id, Func<Topic, TResult> selector);

        IEnumerable<TResult> GetTopicsQuestions<TResult>(Func<Topic, TResult> selector);

        //IEnumerable<TResult> FilterTopics<TResult>(string topicName, Status status, Func<Topic, TResult> selector);
        IEnumerable<TResult> SearchTopics<TResult>(string topicName, Func<Topic, TResult> selector);
    }
}
