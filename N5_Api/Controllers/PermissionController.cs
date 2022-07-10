using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using N5.Core.DTOs;
using N5.Core.Entities;
using N5.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N5.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;
        public PermissionController(IPermissionRepository permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getPermission = await _permissionRepository.Get();
            var permissionDto = _mapper.Map<IEnumerable<PermissionDto>>(getPermission);
            return Ok(permissionDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getPermission = await _permissionRepository.Get(id);
            var permissionDto = _mapper.Map<PermissionDto>(getPermission);
            return Ok(permissionDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PermissionDto permissionDto)
        {
            var permission = _mapper.Map<Permission>(permissionDto);
            await _permissionRepository.InsertPermissions(permission);
            
            return Ok(permission);
        }
    }
}
