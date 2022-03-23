using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestComplex.Domain.Models;

namespace TestComplex.Domain.Infrastucture
{
    public interface IProgressManager
    {
        Task<int> CreateProgress(Result result);
        //Task<int> CreateProgress(Progress progress);
        TResult GetProgressById<TResult>(long id, Func<Progress, TResult> selector);

    }

    public class Result
    {
        public Progress Progress { get; set; }
        public List<long> WrongQuestions { get; set; }
    }
}
