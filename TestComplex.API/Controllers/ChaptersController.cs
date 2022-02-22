using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestComplex.Database.Services.ChaptersAdmin;

namespace TestComplex.API.Controllers
{
    [Route("chapters")]
    public class ChaptersController : TestComplexControllerBase
    {
        [HttpGet("")]
        public IActionResult GetChapters([FromServices] GetChapters getChapters) =>
            Ok(getChapters.Do());

        [HttpGet("{id}")]
        public IActionResult GetChapter(
            int id,
            [FromServices] GetChapter getChapter) =>
            Ok(getChapter.Do(id));

        [HttpPost("")]
        public async Task<IActionResult> CreateChapter(
            [FromBody] CreateChapter.Request request,
            [FromServices] CreateChapter createChapter) =>
            Ok(await createChapter.Do(request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChapter(
            int id,
            [FromServices] DeleteChapter deleteChapter) =>
            Ok(await deleteChapter.Do(id));

        [HttpPut("")]
        public async Task<IActionResult> UpdateChapter(
            [FromBody] UpdateChapter.Request request,
            [FromServices] UpdateChapter updateChapter) =>
            Ok(await updateChapter.Do(request));
    }
}
