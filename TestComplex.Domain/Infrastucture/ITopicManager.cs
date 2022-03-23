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

        IEnumerable<TResult> GetTopicsAll<TResult>(Func<Topic, TResult> selector);
        IEnumerable<TResult> GetTopicsInChapter<TResult>(int chapterId, Func<Topic, TResult> selector);
    }
}
