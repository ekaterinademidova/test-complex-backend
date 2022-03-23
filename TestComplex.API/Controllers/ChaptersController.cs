using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestComplex.Database.Services.Chapters;


namespace TestComplex.API.Controllers
{
    [Route("chapters")]
    public class ChaptersController : TestComplexControllerBase
    {
        [HttpGet("")]
        [AllowAnonymous]
        public IActionResult GetChapters(int categoryId, [FromServices] GetChapters getChapters) =>
            Ok(getChapters.Do(categoryId));

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetChapter(
            int id,
            [FromServices] GetChapter getChapter) =>
            Ok(getChapter.Do(id));

        [HttpPost("")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateChapter(
            [FromBody] CreateChapter.Request request,
            [FromServices] CreateChapter createChapter) =>
            Ok(await createChapter.Do(request));

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteChapter(
            int id,
            [FromServices] DeleteChapter deleteChapter) =>
            Ok(await deleteChapter.Do(id));

        [HttpPut("")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateChapter(
            [FromBody] UpdateChapter.Request request,
            [FromServices] UpdateChapter updateChapter) =>
            Ok(await updateChapter.Do(request));
    }
}
