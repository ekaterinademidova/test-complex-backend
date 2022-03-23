using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Categories
{
    public class GetCategory
    {

        private readonly ICategoryManager _categoryManager;

        public GetCategory(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public CategoryViewModel Do(int id) =>
            _categoryManager.GetCategoryById(id, x => new CategoryViewModel
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
