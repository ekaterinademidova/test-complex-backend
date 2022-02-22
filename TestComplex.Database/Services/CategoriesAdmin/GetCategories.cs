using System.Collections.Generic;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.CategoriesAdmin
{
    [Service]
    public class GetCategories
    {
        private readonly ICategoryManager _categoryManager;

        public GetCategories(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IEnumerable<CategoryViewModel> Do() =>
            _categoryManager.GetCategoriesChapters(x => new CategoryViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            });

        public class CategoryViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }
    }
}
