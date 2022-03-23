using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestComplex.Database.Services.Answers;


namespace TestComplex.API.Controllers
{
    [Route("answers")]
    public class AnswersController : TestComplexControllerBase
    {
        [HttpGet("")]
        [AllowAnonymous]
        public IActionResult GetAnswers(int questionId, [FromServices] GetAnswers getAnswers) =>
            Ok(getAnswers.Do(questionId));

        [HttpGet("{id}")]
        public IActionResult GetAnswer(
            int id,
            [FromServices] GetAnswer getAnswer) =>
            Ok(getAnswer.Do(id));

        [HttpPost("")]
        public async Task<IActionResult> CreateAnswer(
            [FromBody] CreateAnswer.Request request,
            [FromServices] CreateAnswer createAnswer) =>
            Ok(await createAnswer.Do(request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(
            int id,
            [FromServices] DeleteAnswer deleteAnswer) =>
            Ok(await deleteAnswer.Do(id));

        [HttpPut("")]
        public async Task<IActionResult> UpdateAnswer(
            [FromBody] UpdateAnswer.Request request,
            [FromServices] UpdateAnswer updateAnswer) =>
            Ok(await updateAnswer.Do(request));
    }
}
