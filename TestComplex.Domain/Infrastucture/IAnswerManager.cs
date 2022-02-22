using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestComplex.Domain.Models;

namespace TestComplex.Domain.Infrastucture
{
    public interface IAnswerManager
    {
        Task<int> CreateAnswer(Answer answer);
        Task<int> DeleteAnswer(long id);
        Task<int> UpdateAnswer(Answer answer);

        TResult GetAnswerById<TResult>(long id, Func<Answer, TResult> selector);

        IEnumerable<TResult> GetAnswers<TResult>(Func<Answer, TResult> selector);

    }
}
