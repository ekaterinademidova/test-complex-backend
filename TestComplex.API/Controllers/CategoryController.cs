using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//using TestComplex.Database.Services.CategoriesAdmin;
using TestComplex.Database.Services.Categories;

namespace TestComplex.API.Controllers
{
    [Route("categories")]
    public class CategoryController : TestComplexControllerBase
    {
        [HttpGet("")]
        [AllowAnonymous]
        public IActionResult GetCategories([FromServices] GetCategories getCategories) =>
            Ok(getCategories.Do());

        [HttpGet("{id}")]
        public IActionResult GetCategory(
            int id,
            [FromServices] GetCategory getCategory) =>
            Ok(getCategory.Do(id));

        [HttpPost("")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCategory(
            [FromBody] CreateCategory.Request request,
            [FromServices] CreateCategory createCategory) =>
            Ok((await createCategory.Do(request)));

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteCategory(
            int id,
            [FromServices] DeleteCategory deleteCategory) =>
            Ok((await deleteCategory.Do(id)));

        [HttpPut("")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateCategory(
            [FromBody] UpdateCategory.Request request,
            [FromServices] UpdateCategory updateCategory) =>
            Ok((await updateCategory.Do(request)));
    }   
}