using System;
using System.Collections.Generic;

#nullable disable

namespace N5.Core.Entities
{
    public partial class Permission
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long IdTypePermission { get; set; }
        public DateTime? Date { get; set; }

        public virtual TypePermission TypePermission { get; set; }
    }
}
