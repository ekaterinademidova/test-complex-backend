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

        IEnumerable<TResult> GetChaptersAll<TResult>(Func<Chapter, TResult> selector);
        IEnumerable<TResult> GetChaptersInCategory<TResult>(int categoryId, Func<Chapter, TResult> selector);

        TResult GetChapterById<TResult>(long id, Func<Chapter, TResult> selector);
    }
}
