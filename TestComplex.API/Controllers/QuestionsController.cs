using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestComplex.Database.Services.Questions;

namespace TestComplex.API.Controllers
{
    [Route("questions")]
    public class QuestionsController : TestComplexControllerBase
    {
        [HttpGet("")]
        [AllowAnonymous]
        public IActionResult GetQuestions(int topicId, [FromServices] GetQuestions getQuestions) =>
            Ok(getQuestions.Do(topicId));

        [HttpGet("{id}")]
        public IActionResult GetQuestion(
            int id,
            [FromServices] GetQuestion getQuestion) =>
            Ok(getQuestion.Do(id));

        [HttpPost("")]
        public async Task<IActionResult> CreateQuestion(
            [FromBody] CreateQuestion.Request request,
            [FromServices] CreateQuestion createQuestion) =>
            Ok(await createQuestion.Do(request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(
            int id,
            [FromServices] DeleteQuestion deleteQuestion) =>
            Ok(await deleteQuestion.Do(id));

        [HttpPut("")]
        public async Task<IActionResult> UpdateQuestion(
            [FromBody] UpdateQuestion.Request request,
            [FromServices] UpdateQuestion updateQuestion) =>
            Ok(await updateQuestion.Do(request));
    }
}
