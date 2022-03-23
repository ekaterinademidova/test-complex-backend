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
    public class CategoryManager : ICategoryManager
    {
        private readonly ApplicationDbContext _ctx;

        public CategoryManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<int> CreateCategory(Category category)
        {
            _ctx.Categories.Add(category);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteCategory(long id)
        {
            var category = _ctx.Categories.FirstOrDefault(x => x.Id == id);
            _ctx.Categories.Remove(category);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> UpdateCategory(Category сategory)
        {
            _ctx.Categories.Update(сategory);

            return _ctx.SaveChangesAsync();
        }

        public TResult GetCategoryById<TResult>(long id, Func<Category, TResult> selector)
        {
            return _ctx.Categories
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }

        public IEnumerable<TResult> GetCategoriesChapters<TResult>(
            Func<Category, TResult> selector)
        {
            return _ctx.Categories
                .Include(x => x.Chapters)
                .OrderBy(x => x.Title)
                .Select(selector)
                .ToList();
        }
    }
}
