using Microsoft.AspNetCore.Mvc;
using N5.Infrastructure.Repositories;

namespace N5.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var post = new PostReporitory().GetPosts();
            return Ok(post);
        }
    }
}
