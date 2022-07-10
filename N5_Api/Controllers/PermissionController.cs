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
            return Ok(new Response<IEnumerable<PermissionDto>>(permissionDto)
            {
                State = 0,
                Data = permissionDto,
                Message = "Solicitud Correcta"
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getPermission = await _permissionRepository.Get(id);
            var permissionDto = _mapper.Map<PermissionDto>(getPermission);
            return Ok(new Response<PermissionDto>(permissionDto)
            {
                State = 0,
                Data = permissionDto,
                Message = "Solicitud Correcta"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(PermissionDto permissionDto)
        {
            var permission = _mapper.Map<Permission>(permissionDto);
            await _permissionRepository.InsertPermissions(permission);
            permissionDto = _mapper.Map<PermissionDto>(permission);

            return Ok(new Response<PermissionDto>(permissionDto)
            {
                State = 0,
                Data = permissionDto,
                Message = "Solicitud Correcta"
            });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, PermissionDto permissionDto)
        {
            var permission = _mapper.Map<Permission>(permissionDto);
            permission.Id = id;
            await _permissionRepository.UpdatePermissions(permission);

            return Ok(permission);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _permissionRepository.DeletePermissions(id);
            if (result)
            {
                return Ok(new Response<bool>(result) {
                    State = 0,
                    Data = result,
                    Message = "Solicitud Correcta"
                });
            }
            else
            {
                return BadRequest(new Response<bool>(result)
                {
                    State = 1,
                    Data = result,
                    Message = "Solicitud Incorrecta"
                });
            }
        }
    }
}
