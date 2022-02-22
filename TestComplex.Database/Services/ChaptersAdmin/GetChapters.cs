using System.Collections.Generic;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.ChaptersAdmin
{ 
    [Service]
    public class GetChapters
    {
        private readonly IChapterManager _chapterManager;

        public GetChapters(IChapterManager chapterManager)
        {
            _chapterManager = chapterManager;
        }

        public IEnumerable<ChapterViewModel> Do() =>
            _chapterManager.GetChaptersTopics(x => new ChapterViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CategoryId = x.CategoryId
            });

        public class ChapterViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public long CategoryId { get; set; }
        }
    }
}
