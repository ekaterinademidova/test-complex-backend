using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestComplex.API.Controllers
{
    [ApiController]
    [Authorize]
    public class TestComplexControllerBase : ControllerBase
    {
        
    }
}