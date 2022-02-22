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
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }

        public IEnumerable<TResult> GetQuestionsAnswers<TResult>(
           Func<Question, TResult> selector)
        {
            return _ctx.Questions
                .Include(x => x.Answers)
                .OrderBy(x => x.Title)
                .Select(selector)
                .ToList();
        }

        public IEnumerable<TResult> SearchQuestions<TResult>(string questionName, 
            Func<Question, TResult> selector)
        {
            var questions = _ctx.Questions
               .ToList();
            if (questionName != null)
            {
                questions = questions
                .Where(x => x.Title.Contains(questionName))
                .ToList();
            }

            questions = questions
                .OrderBy(x => x.Title)
                .ToList();

            return questions.Select(selector).ToList();
        }
    }
}
