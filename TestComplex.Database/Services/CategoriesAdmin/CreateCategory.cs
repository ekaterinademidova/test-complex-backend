using System;
using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;
using TestComplex.Domain.Models;

namespace TestComplex.Database.Services.CategoriesAdmin
{
    [Service]
    public class CreateCategory
    {
        private readonly ICategoryManager _categoryManager;

        public CreateCategory(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public async Task<Response> Do(Request request)
        {
            var category = new Category
            {
                Title = request.Title,
                Description = request.Description
            };

            if (await _categoryManager.CreateCategory(category) <= 0)
            {
                throw new Exception("Failed to create product");
            }

            return new Response
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description
            };
        }

        public class Request
        {
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
