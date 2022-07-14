using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using N5.Api.Model.Response;
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
        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;
        public PermissionController(IPermissionService permissionService, IMapper mapper)
        {
            _permissionService = permissionService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var getPermission = _permissionService.Get();
            var permissionDto = _mapper.Map<IEnumerable<PermissionDto>>(getPermission);
            return Ok(permissionDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getPermission = await _permissionService.Get(id);
            var permissionDto = _mapper.Map<PermissionDto>(getPermission);
            return Ok(permissionDto);
        }

        [HttpPost("find")]
        public async Task<IActionResult> Find(PermissionFindDto permissionFindDto)
        {
            var getPermission = await _permissionService.Find(permissionFindDto);
            var permissionDto = _mapper.Map<IEnumerable<PermissionDto>>(getPermission);
            return Ok(permissionDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PermissionDto permissionDto)
        {
            var permission = _mapper.Map<PermissionEntity>(permissionDto);
            await _permissionService.InsertPermissions(permission);
            permissionDto = _mapper.Map<PermissionDto>(permission);

            return Ok(permissionDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PermissionDto permissionDto)
        {
            var permission = _mapper.Map<PermissionEntity>(permissionDto);
            var result = await _permissionService.UpdatePermissions(permission);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _permissionService.DeletePermissions(id);
            return Ok(result);
        }
    }
}
