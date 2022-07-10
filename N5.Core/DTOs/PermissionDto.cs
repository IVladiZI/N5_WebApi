using System;

namespace N5.Core.DTOs
{
    public class PermissionDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public long IdTypePermission { get; set; }
        public DateTime? Date { get; set; }
    }
}
