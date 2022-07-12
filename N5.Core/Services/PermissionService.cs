using N5.Core.DTOs;
using N5.Core.Entities;
using N5.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Core.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<PermissionEntity> Get()
        {
           return _unitOfWork.PermissionRepository.GetAll().ToList();
        }
        public async Task<PermissionEntity> Get(long Id)
        {
            return await _unitOfWork.PermissionRepository.GetById(Id);
        }
        public async Task<IEnumerable<PermissionEntity>> Find(PermissionFindDto permissionFindDto)
        {
            var permission = await _unitOfWork.PermissionRepository.FindAsync();
            if (permission.Count()>0)
            {
                if (permissionFindDto.Name != null)
                {
                    permission = permission.Where(x => x.Name.ToLower().Contains(permissionFindDto.Name.ToLower()) || x.LastName.ToLower().Contains(permissionFindDto.Name.ToLower()));
                }

                if (permissionFindDto.IdTypePermission != null)
                {
                    permission = permission.Where(x => x.IdTypePermission == permissionFindDto.IdTypePermission);
                }
            }
            return permission;

        }

        public async Task<bool> DeletePermissions(long Id)
        {
            var permission = await Get(Id);
            if (permission != null)
            {
                _unitOfWork.PermissionRepository.Delete(permission);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
            
        }

        public async Task InsertPermissions(PermissionEntity Permission)
        {
            Permission.Date = DateTime.Now;
            await _unitOfWork.PermissionRepository.Insert(Permission);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePermissions(PermissionEntity permissionEntity)
        {
            var permission = await Get(permissionEntity.Id);
            if (permission != null)
            {
                permission.IdTypePermission = permissionEntity.IdTypePermission;
                permission.Name = permissionEntity.Name;
                permission.LastName = permissionEntity.LastName;
                _unitOfWork.PermissionRepository.Update(permission);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
