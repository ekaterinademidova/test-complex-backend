using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.ChaptersAdmin
{
    [Service]
    public class GetChapter
    {

        private readonly IChapterManager _chapterManager;

        public GetChapter(IChapterManager chapterManager)
        {
            _chapterManager = chapterManager;
        }

        public ChapterViewModel Do(int id) =>
            _chapterManager.GetChapterById(id, x => new ChapterViewModel
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
