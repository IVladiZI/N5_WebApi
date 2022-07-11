using System;
using System.Collections.Generic;

#nullable disable

namespace N5.Core.Entities
{
    public partial class TypePermissionEntity : BaseEntity
    {
        public TypePermissionEntity()
        {
            Permissions = new HashSet<PermissionEntity>();
        }
        public string Description { get; set; }

        public virtual ICollection<PermissionEntity> Permissions { get; set; }
    }
}
