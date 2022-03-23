using System.Collections.Generic;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Chapters
{ 
    public class GetChapters
    {
        private readonly IChapterManager _chapterManager;

        public GetChapters(IChapterManager chapterManager)
        {
            _chapterManager = chapterManager;
        }

        public IEnumerable<ChapterViewModel> Do(int categoryId)
        {
            if (categoryId == 0)
            {
                return _chapterManager.GetChaptersAll(x => new ChapterViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    CategoryId = x.CategoryId,

                    TopicsCount = x.Topics.Count
                });
            }
            return _chapterManager.GetChaptersInCategory(categoryId, x => new ChapterViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CategoryId = x.CategoryId,

                TopicsCount = x.Topics.Count
            });
        }

        public class ChapterViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public long CategoryId { get; set; }
            public int TopicsCount { get; set; }
        }
    }
}
