using System;
using System.Linq;
using System.Threading.Tasks;
using TestComplex.Database;
using TestComplex.Domain.Infrastucture;
using TestComplex.Domain.Models;

namespace TestComplex.Domain.Managers
{
    public class ProgressManager : IProgressManager
    {
        private readonly ApplicationDbContext _ctx;

        public ProgressManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<int> CreateProgress(Progress progress)
        {
            _ctx.Progresses.Add(progress);

            return _ctx.SaveChangesAsync();
        }

        public TResult GetProgressById<TResult>(long id, Func<Progress, TResult> selector)
        {
            return _ctx.Progresses
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }
    }
}
