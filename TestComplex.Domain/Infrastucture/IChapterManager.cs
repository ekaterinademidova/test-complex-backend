using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestComplex.Domain.Models;

namespace TestComplex.Domain.Infrastucture
{
    public interface IChapterManager
    {
        Task<int> CreateChapter(Chapter chapter);
        Task<int> DeleteChapter(long id);
        Task<int> UpdateChapter(Chapter chapter);

        IEnumerable<TResult> GetChaptersTopics<TResult>(Func<Chapter, TResult> selector);

        TResult GetChapterById<TResult>(long id, Func<Chapter, TResult> selector);
    }
}
