using System.Threading.Tasks;
using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Chapters
{
    public class DeleteChapter
    {
        private readonly IChapterManager _chapterManager;

        public DeleteChapter(IChapterManager chapterManager)
        {
            _chapterManager = chapterManager;
        }

        public Task<int> Do(long id)
        {
            return _chapterManager.DeleteChapter(id);
        }
    }
    
}
