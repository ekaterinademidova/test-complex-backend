using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.ChaptersAdmin
{
    [Service]
    public class UpdateChapter
    {
        private readonly IChapterManager _chapterManager;

        public UpdateChapter(IChapterManager chapterManager)
        {
            _chapterManager = chapterManager;
        }

        public async Task<Response> Do(Request request)
        {
            var chapter = _chapterManager.GetChapterById(request.Id, x => x);

            chapter.Title = request.Title;
            chapter.Description = request.Description;
            chapter.CategoryId = request.CategoryId;

            await _chapterManager.UpdateChapter(chapter);

            return new Response
            {
                Id = chapter.Id,
                Title = chapter.Title,
                Description = chapter.Description,
                CategoryId = chapter.CategoryId
            };
        }

        public class Request
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public long CategoryId { get; set; }
        }

        public class Response
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public long CategoryId { get; set; }
        }
    }
}
