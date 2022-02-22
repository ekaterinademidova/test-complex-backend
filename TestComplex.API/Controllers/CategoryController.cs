using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestComplex.Database.Services.CategoriesAdmin;

namespace TestComplex.API.Controllers
{
    [Route("categories")]
    public class CategoryController : TestComplexControllerBase
    {
        [HttpGet("")]
        public IActionResult GetCategories([FromServices] GetCategories getCategories) =>
            Ok(getCategories.Do());

        [HttpGet("{id}")]
        public IActionResult GetCategory(
            int id,
            [FromServices] GetCategory getCategory) =>
            Ok(getCategory.Do(id));

        [HttpPost("")]
        public async Task<IActionResult> CreateCategory(
            [FromBody] CreateCategory.Request request,
            [FromServices] CreateCategory createCategory) =>
            Ok((await createCategory.Do(request)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(
            int id,
            [FromServices] DeleteCategory deleteCategory) =>
            Ok((await deleteCategory.Do(id)));

        [HttpPut("")]
        public async Task<IActionResult> UpdateCategory(
            [FromBody] UpdateCategory.Request request,
            [FromServices] UpdateCategory updateCategory) =>
            Ok((await updateCategory.Do(request)));
    }   
}