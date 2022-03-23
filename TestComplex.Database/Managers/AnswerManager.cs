using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestComplex.Database;
using TestComplex.Domain.Infrastucture;
using TestComplex.Domain.Models;

namespace TestComplex.Domain.Managers
{
    public class AnswerManager : IAnswerManager
    {
        private readonly ApplicationDbContext _ctx;

        public AnswerManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public Task<int> CreateAnswer(Answer answer)
        {
            _ctx.Answers.Add(answer);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteAnswer(long id)
        {
            var answer = _ctx.Answers.FirstOrDefault(x => x.Id == id);
            _ctx.Answers.Remove(answer);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> UpdateAnswer(Answer answer)
        {
            _ctx.Answers.Update(answer);

            return _ctx.SaveChangesAsync();
        }

        public TResult GetAnswerById<TResult>(long id, Func<Answer, TResult> selector)
        {
            return _ctx.Answers
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }

        public IEnumerable<TResult> GetAnswers<TResult>(
            long questionId,
            Func<Answer, TResult> selector)
        {
            return _ctx.Answers
                .Where(x => x.QuestionId == questionId)
                .OrderBy(x => x.Title)
                .Select(selector)
                .ToList();
        }
    }
}
