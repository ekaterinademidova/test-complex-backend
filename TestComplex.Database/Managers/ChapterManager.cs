using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestComplex.Database;
using TestComplex.Domain.Infrastucture;
using TestComplex.Domain.Models;

namespace TestComplex.Domain.Managers
{
    public class ChapterManager : IChapterManager
    {
        private readonly ApplicationDbContext _ctx;

        public ChapterManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<int> CreateChapter(Chapter chapter)
        {
            _ctx.Chapters.Add(chapter);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteChapter(long id)
        {
            var chapter = _ctx.Chapters.FirstOrDefault(x => x.Id == id);
            _ctx.Chapters.Remove(chapter);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> UpdateChapter(Chapter chapter)
        {
            _ctx.Chapters.Update(chapter);

            return _ctx.SaveChangesAsync();
        }

        public TResult GetChapterById<TResult>(long id, Func<Chapter, TResult> selector)
        {
            return _ctx.Chapters
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }

        public IEnumerable<TResult> GetChaptersTopics<TResult>(
            Func<Chapter, TResult> selector)
        {
            return _ctx.Chapters
                .Include(x => x.Topics)
                .OrderBy(x => x.Title)
                .Select(selector)
                .ToList();
        }

        //public IEnumerable<TResult> FilterChapters<TResult>(string chapterName,
        //    Func<Chapter, TResult> selector)
        //{
        //    var chapters = _ctx.Chapters
        //       .ToList();
        //    if (chapterName != null)
        //    {
        //        chapters = chapters
        //        .Where(x => x.Title.Contains(chapterName))
        //        .ToList();
        //    }

        //    chapters = chapters
        //        .OrderBy(x => x.Title)
        //        .ToList();

        //    return chapters.Select(selector).ToList();

        //}
    }
}
