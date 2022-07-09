using System;
using System.Collections.Generic;

#nullable disable

namespace N5.Core.Entities
{
    public partial class TypePermission
    {
        public TypePermission()
        {
            Permissions = new HashSet<Permission>();
        }

        public long Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
