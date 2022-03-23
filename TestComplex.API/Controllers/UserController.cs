using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestComplex.Database.Services.Users;

namespace TestComplex.API.Controllers
{
    [Route("users")]
    public class UserController : ControllerBase
    {
        [HttpGet("public")]
        [AllowAnonymous]
        public IActionResult Public()
        {
            return Ok(new
            {
                Message = "Hello from a public endpoint! You don't need to be authenticated to see this."
            });
        }

        [HttpGet("{userId}")]
        public IActionResult Private(
            long userId, 
            [FromServices] GetUser getUser) =>
            Ok(getUser.Do(userId));

        [HttpGet("private-scoped")]
        public IActionResult Scoped()
        {
            return Ok(new
            {
                Message = "Hello from a private endpoint! You need to be authenticated and have a scope of read:messages to see this."
            });
        }

        // This is a helper action. It allows you to easily view all the claims of the token.
        [HttpGet("claims")]
        public IActionResult Claims()
        {
            return Ok(User.Claims.Select(c =>
                new
                {
                    c.Type,
                    c.Value
                }));
        }
    }   
}