using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TestComplex.Database;
using TestComplex.Database.Services.Progresses;

namespace TestComplex.API.Controllers
{
    [Route("progresses")]
    public class ProgressesController : TestComplexControllerBase
    {
        private readonly ApplicationDbContext _ctx;

        public ProgressesController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateProgress(
            [FromBody] CreateProgress.Request request,
            [FromServices] CreateProgress createProgress)
        {
            var data = _ctx.Questions
               .Where(x => x.TopicId == request.TopicId)
               .ToArray();
            return Ok(await createProgress.Do(request, data));

        }
    }
}