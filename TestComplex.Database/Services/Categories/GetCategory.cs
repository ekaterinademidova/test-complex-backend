using System.Collections.Generic;
using System.Linq;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Categories
{
    [Service]
    public class GetCategory
    {

        private readonly ICategoryManager _categoryManager;

        public GetCategory(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public CategoryViewModel Do(int id)
        {
            return _categoryManager
                .GetCategoryById(id, x => new CategoryViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,

                    Chapters = x.Chapters.Select(y => new ChapterViewModel
                    {
                        Id = y.Id,
                        Title = y.Title,
                        Description = y.Description
                    })
                });
        }

        public class CategoryViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public IEnumerable<ChapterViewModel> Chapters { get; set; }

        }

        public class ChapterViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }
    }
}
