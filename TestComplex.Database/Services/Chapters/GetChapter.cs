using System.Collections.Generic;
using System.Linq;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Chapters
{
    [Service]
    public class GetChapter
    {
        private readonly IChapterManager _chapterManager;

        public GetChapter(IChapterManager chapterManager)
        {
            _chapterManager = chapterManager;
        }

        public ChapterViewModel Do(int id)
        {
            return _chapterManager.GetChapterById(id, x => new ChapterViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CategoryId = x.CategoryId,

                Topics = x.Topics.Select(y => new TopicViewModel
                {
                    Id = y.Id,
                    Title = y.Title,
                    Description = y.Description,
                    Lecture = y.Lecture,
                    Lab = y.Lab
                })
            });
        }

        public class ChapterViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public long CategoryId { get; set; }
            public IEnumerable<TopicViewModel> Topics { get; set; }

        }

        public class TopicViewModel
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Lecture { get; set; }
            public string Lab { get; set; }
        }
    }
}
