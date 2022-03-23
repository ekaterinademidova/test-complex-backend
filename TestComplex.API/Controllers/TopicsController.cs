using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//using TestComplex.Database.Services.ChaptersAdmin;
using TestComplex.Database.Services.Topics;


namespace TestComplex.API.Controllers
{
    [Route("topics")]
    public class TopicsController : TestComplexControllerBase
    {
        [HttpGet("")]
        [AllowAnonymous]
        public IActionResult GetTopics(int chapterId, [FromServices] GetTopics getTopics) =>
            Ok(getTopics.Do(chapterId));

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetTopic(
            int id,
            [FromServices] GetTopic getTopic) =>
            Ok(getTopic.Do(id));

        [HttpPost("")]
        public async Task<IActionResult> CreateTopic(
            [FromBody] CreateTopic.Request request,
            [FromServices] CreateTopic createTopic) =>
            Ok(await createTopic.Do(request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(
            int id,
            [FromServices] DeleteTopic deleteTopic) =>
            Ok(await deleteTopic.Do(id));

        [HttpPut("")]
        public async Task<IActionResult> UpdateTopic(
            [FromBody] UpdateTopic.Request request,
            [FromServices] UpdateTopic updateTopic) =>
            Ok(await updateTopic.Do(request));
    }
}
