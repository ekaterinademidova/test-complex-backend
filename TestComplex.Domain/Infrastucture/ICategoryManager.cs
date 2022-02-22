using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestComplex.Domain.Models;

namespace TestComplex.Domain.Infrastucture
{
    public interface ICategoryManager
    {
        Task<int> CreateCategory(Category category);
        Task<int> DeleteCategory(long id);
        Task<int> UpdateCategory(Category category);

        TResult GetCategoryById<TResult>(long id, Func<Category, TResult> selector);

        IEnumerable<TResult> GetCategoriesChapters<TResult>(Func<Category, TResult> selector);
    }
}
