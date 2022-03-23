using System;
using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;
using TestComplex.Domain.Models;

namespace TestComplex.Database.Services.Chapters
{
    public class CreateChapter
    {
        private readonly IChapterManager _chapterManager;

        public CreateChapter(IChapterManager chapterManager)
        {
            _chapterManager = chapterManager;
        }

        public async Task<Response> Do(Request request)
        {
            var chapter = new Chapter
            {
                Title = request.Title,
                Description = request.Description,
                CategoryId = request.CategoryId
            };

            if (await _chapterManager.CreateChapter(chapter) <= 0)
            {
                throw new Exception("Failed to create chapter");
            }

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
