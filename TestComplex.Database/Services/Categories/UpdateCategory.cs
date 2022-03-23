using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Categories
{
    public class UpdateCategory
    {
        private readonly ICategoryManager _categoryManager;

        public UpdateCategory(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public async Task<Response> Do(Request request)
        {
            var category = _categoryManager.GetCategoryById(request.Id, x => x);

            category.Title = request.Title;
            category.Description = request.Description;

            await _categoryManager.UpdateCategory(category);

            return new Response
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description
            };
        }

        public class Request
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public class Response
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }
    }
}
