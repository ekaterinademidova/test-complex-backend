using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestComplex.Database;
using TestComplex.Domain.Infrastucture;
using TestComplex.Domain.Models;

namespace TestComplex.Domain.Managers
{
    public class TopicManager : ITopicManager
    {
        private readonly ApplicationDbContext _ctx;

        public TopicManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public Task<int> CreateTopic(Topic topic)
        {
            _ctx.Topics.Add(topic);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteTopic(long id)
        {
            var topic = _ctx.Topics.FirstOrDefault(x => x.Id == id);
            _ctx.Topics.Remove(topic);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> UpdateTopic(Topic topic)
        {
            _ctx.Topics.Update(topic);

            return _ctx.SaveChangesAsync();
        }

        public TResult GetTopicById<TResult>(long id, Func<Topic, TResult> selector)
        {
            return _ctx.Topics
                .Include(x => x.Questions)
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }

        public IEnumerable<TResult> GetTopicsAll<TResult>(
          Func<Topic, TResult> selector)
        {
            return _ctx.Topics
                .Include(x => x.Questions)
                .OrderBy(x => x.Title)
                .Select(selector)
                .ToList();
        }

        public IEnumerable<TResult> GetTopicsInChapter<TResult>(
            int chapterId,
            Func<Topic, TResult> selector)
        {
            return _ctx.Topics
                .Include(x => x.Questions)
                .Where(x => x.ChapterId == chapterId)
                .OrderBy(x => x.Title)
                .Select(selector)
                .ToList();
        }

        //public IEnumerable<TResult> GetTopicsQuestions<TResult>(
        //    int chapterId,
        //    Func<Topic, TResult> selector)
        //{
        //    return _ctx.Topics
        //        .Include(x => x.Questions)
        //         .Where(x => x.ChapterId == chapterId)
        //        .OrderBy(x => x.Title)
        //        .Select(selector)
        //        .ToList();
        //}

        //public IEnumerable<TResult> SearchTopics<TResult>(string topicName, 
        //   int chapterId,
        //   Func<Topic, TResult> selector)
        //{
        //    var topics = _ctx.Topics
        //        .Where(x => x.ChapterId == chapterId)
        //       .ToList();
        //    if (topicName != null)
        //    {
        //        topics = topics
        //        .Where(x => x.Title.Contains(topicName))
        //        .ToList();
        //    }

        //    topics = topics
        //        .OrderBy(x => x.Title)
        //        .ToList();

        //    return topics.Select(selector).ToList();

        //}
    }
}
