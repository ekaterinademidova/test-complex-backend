using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestComplex.Domain.Models;

namespace TestComplex.Domain.Infrastucture
{
    public interface IQuestionManager
    {
        Task<int> CreateQuestion(Question question);
        Task<int> DeleteQuestion(long id);
        Task<int> UpdateQuestion(Question question);

        TResult GetQuestionById<TResult>(long id, Func<Question, TResult> selector);

        IEnumerable<TResult> GetQuestionsAnswers<TResult>(int topicId, Func<Question, TResult> selector);

    }
}
