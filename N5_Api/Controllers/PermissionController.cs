using Microsoft.AspNetCore.Mvc;
using N5.Core.Interfaces;
using System.Threading.Tasks;

namespace N5.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository _permissionRepository;
        public PermissionController(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var post = await _permissionRepository.Get();
            return Ok(post);
        }
    }
}
