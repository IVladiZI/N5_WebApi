using Microsoft.AspNetCore.Mvc;
using N5.Core.Interfaces;
using System.Threading.Tasks;

namespace N5.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypePermissionController : ControllerBase
    {
        private readonly ITypePermissionRepository _typePermissionRepository;
        public TypePermissionController(ITypePermissionRepository typePermissionRepository)
        {
            _typePermissionRepository = typePermissionRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getTypePermission = await _typePermissionRepository.Get();
            return Ok(getTypePermission);
        }
    }
}
