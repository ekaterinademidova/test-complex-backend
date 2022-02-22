using System;
using System.Threading.Tasks;
using TestComplex.Domain.Models;

namespace TestComplex.Domain.Infrastucture
{
    public interface IProgressManager
    {
        Task<int> CreateProgress(Progress progress);

        TResult GetProgressById<TResult>(long id, Func<Progress, TResult> selector);
    }
}
