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
    public class QuestionManager : IQuestionManager
    {
        private readonly ApplicationDbContext _ctx;

        public QuestionManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public Task<int> CreateQuestion(Question question)
        {
            _ctx.Questions.Add(question);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteQuestion(long id)
        {
            var question = _ctx.Questions.FirstOrDefault(x => x.Id == id);
            _ctx.Questions.Remove(question);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> UpdateQuestion(Question question)
        {
            _ctx.Questions.Update(question);

            return _ctx.SaveChangesAsync();
        }

        public TResult GetQuestionById<TResult>(long id, Func<Question, TResult> selector)
        {
            return _ctx.Questions
                .Include(x => x.Answers)
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }

        public IEnumerable<TResult> GetQuestionsAnswers<TResult>(
           int topicId,
           Func<Question, TResult> selector)
        {
            return _ctx.Questions
                .Include(x => x.Answers)
                .Where(x => x.TopicId == topicId)
                .OrderBy(x => x.Title)
                .Select(selector)
                .ToList();
        }
    }
}
